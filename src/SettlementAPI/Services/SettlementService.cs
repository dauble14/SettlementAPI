using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using SettlementAPI.Exceptions;
using SettlementAPI.Models;
using SettlementAPI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SettlementAPI.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Options.IdentityOptions _identity;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SettlementDbContext _context;
        private readonly IProductService _products;
        public SettlementService(
            IUnitOfWork unitOfWork,
            Options.IdentityOptions identity,
            IMapper mapper,
            UserManager<User> userManager
            , SettlementDbContext context,
            IProductService products
            )
        {
            _unitOfWork = unitOfWork;
            _identity = identity;
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
            _products = products;
        }

        public async Task<CreateSettlementDTO> CreateAsync(CreateSettlementDTO model)
        {
            var userMail = _identity.UserMail;
            var user = await _userManager.FindByNameAsync(userMail);
            

            var settlement = new Settlement
            {
                Currency = model.Currency,
                Amount = model.Amount,
                UserId =user.Id

            };

            await _unitOfWork.Settlements.Insert(settlement);
            await _unitOfWork.CompleteAsync();
            return model;
        }

        public void CheckDebt() //User owner, User debpter
        {
            try
            {
                Settlement settlement = _context.Settlements
                .Include(s => s.ProductSettlementList).ThenInclude(ps => ps.Product)
                .Include(s => s.ProductSettlementList).ThenInclude(ps => ps.User).FirstOrDefault();
                List<ProductSettlement> productList = settlement.ProductSettlementList.Where(ps => ps.User.FirstName == "Jacobinho").ToList();
                double amount = productList.Select(p => p.Product).Sum(p => p.FullPrice);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SettlementDTO> CreateSettlementAsync(List<ProductToAddDTO> productsAndUsers, string currency)
        {
            var userMail = _identity.UserMail;
            var loggedUser = await _userManager.FindByNameAsync(userMail);
            
            foreach (var productAndUsers in productsAndUsers)
            {
                await IsFriendOrOwner(productAndUsers.UsersWhoTakeProduct);
            }

            if (productsAndUsers.Count == 0)
                return null;
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var newSettlement = new Settlement
                {
                    UserId = loggedUser.Id,
                    CreatedAtTime = DateTime.Now,
                    ModifiedAtTime = DateTime.Now,
                    Currency = currency,
                    Amount=0
                };
                await _context.Settlements.AddAsync(newSettlement);
                await _context.SaveChangesAsync();
            
                foreach (var product in productsAndUsers)
                {
                    await _products.AddProductToSettlementAsync( product, newSettlement.SettlementId);
                }
                ts.Complete();

                var newSettlementDTO = _mapper.Map<Settlement, SettlementDTO>(newSettlement);
                return newSettlementDTO;
            }

        }

        private async Task<bool> IsFriendOrOwner(string[] usersIds)
        {
            var userMail = _identity.UserMail;
            var loggedUser = await _userManager.FindByNameAsync(userMail);
            
            foreach (var userId in usersIds)
            {
                if (_context.Friends.Any(x => x.UserId == loggedUser.Id && x.FriendUserId == userId) || userId == loggedUser.Id)
                { }
                else
                {
                    throw new NotFoundException($"User with id: {userId} isn't you friend!");
                }
            }
            return true;
        }

        public async Task<List<SettlementOverallDTO>> GetAllSettlementsAsync(string currency, string filter, string sortBy="-created")
        {
            var userMail = _identity.UserMail;
            var loggedUser = await _userManager.FindByNameAsync(userMail);

            if (string.IsNullOrEmpty(filter))
                filter = "week";
            var upToDay = new DateTime();
            
            switch (filter)
            {
                case "hour":
                    upToDay = DateTime.Now.AddHours(-1);
                    break;
                case "month":
                    upToDay= DateTime.Now.AddDays(-30);
                    break;
                case "day":
                    upToDay = DateTime.Now.AddDays(-1);
                    break;
                case "year":
                    upToDay = DateTime.Now.AddDays(-365);
                    break;
                default:
                    upToDay = DateTime.Now.AddDays(-7);
                    break;
            }

            var userSettlementsList = new List<Settlement>();
            //switch (sortBy)
            //{
            //    case "created":
            //        userSettlementsList = await _context.Settlements
            //                                .Where(s => s.Currency == currency && s.CreatedAtTime >= upToDay)
            //                                .Include(s => s.ProductSettlementList.Where(ps => ps.UserId == loggedUser.Id))
            //                                .Include(s => s.CreatedByUser).OrderBy(x => x.CreatedAtTime).ToListAsync();
            //        break;
            //    case "-modified":
            //        userSettlementsList = await _context.Settlements
            //                                .Where(s => s.Currency == currency && s.CreatedAtTime >= upToDay)
            //                                .Include(s => s.ProductSettlementList.Where(ps => ps.UserId == loggedUser.Id))
            //                                .Include(s => s.CreatedByUser).OrderByDescending(x => x.ModifiedAtTime).ToListAsync();
            //        break;
            //    case "modified":
            //        userSettlementsList = await _context.Settlements
            //                                .Where(s => s.Currency == currency && s.CreatedAtTime >= upToDay)
            //                                .Include(s => s.ProductSettlementList.Where(ps => ps.UserId == loggedUser.Id))
            //                                .Include(s => s.CreatedByUser).OrderBy(x => x.ModifiedAtTime).ToListAsync();
            //        break;

            //    default:
            //        userSettlementsList = await _context.Settlements
            //                                .Where(s => s.Currency == currency && s.CreatedAtTime >= upToDay)
            //                                .Include(s => s.ProductSettlementList.Where(ps => ps.UserId == loggedUser.Id))
            //                                .Include(s => s.CreatedByUser).OrderByDescending(x => x.CreatedAtTime).ToListAsync();
            //        break;
            //}

            var querable = _context.Settlements.Where(s => s.Currency == currency && s.CreatedAtTime >= upToDay)
                        .Include(s => s.ProductSettlementList.Where(ps => ps.UserId == loggedUser.Id)).Include(s => s.CreatedByUser);

            switch (sortBy)
            {
                case "created":
                    userSettlementsList =await querable.OrderBy(x => x.CreatedAtTime).ToListAsync();
                    break;
                case "-modified":
                    userSettlementsList = await querable.OrderByDescending(x => x.ModifiedAtTime).ToListAsync();
                    break;
                case "modified":
                    userSettlementsList = await querable.OrderBy(x => x.ModifiedAtTime).ToListAsync();
                    break;

                default:
                    userSettlementsList = await querable.OrderByDescending(x => x.CreatedAtTime).ToListAsync();

                    break;
            }

            
            var userSettlementsListDTO = new List<SettlementOverallDTO>();
            foreach (var userSettlement in userSettlementsList)
            {
                userSettlementsListDTO.Add(new SettlementOverallDTO()
                {
                    SettlementId=userSettlement.SettlementId,
                    IsCreator= (userSettlement.CreatedByUser.Id==loggedUser.Id),
                    CreatedAtTime= userSettlement.CreatedAtTime,
                    ModifiedAtTime= userSettlement.ModifiedAtTime
                });
            }
            return userSettlementsListDTO;
        }
    }
}

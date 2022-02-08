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

            var querable = _context.ProductSettlements
                .Where(ps => ps.UserId == loggedUser.Id || ps.Settlement.UserId==loggedUser.Id)
                .Include(ps => ps.Settlement).ThenInclude(s => s.CreatedByUser)
                .Where(ps=>ps.Settlement.Currency==currency && ps.Settlement.CreatedAtTime >= upToDay)
                .Select(ps => ps.Settlement)
                .Distinct();

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

        public async Task<SettlementDetailDTO> GetSettlementDetail(int settlementId)
        {
            var settlement =await _context.Settlements.FirstOrDefaultAsync(s => s.SettlementId == settlementId);
            if(settlement==null) 
                throw new NotFoundException("Settlement with given id not found");
            
            var userId = _identity.UserId;
            var products = await _context.ProductSettlements
                    .Where(ps => ps.SettlementId == settlementId && ps.UserId == userId)
                    .Include(ps => ps.Product)
                    .Select(p => p.Product).ToListAsync();
            if (products.Count==0 && settlement.UserId!=userId)
                throw new ForbidException("You aren't included in this settlement");
            double settlementAmount = Math.Round(products.Sum(p => p.FullPrice), 2);
            var resultSettlementDTO = new SettlementDetailDTO
            {
                SettlementId = settlement.SettlementId,
                Currency = settlement.Currency,
                Products = _mapper.Map<List<Product>, List<ProductDTO>>(products),
                Amount = settlementAmount
            };
                       
            return resultSettlementDTO;
        }

        public async Task<SettlementDetailForCreatorDTO> GetSettlementDetailForCreatorAsync(int settlementId)
        {
            var userId = _identity.UserId;
            var settlement = await _context.Settlements.FirstOrDefaultAsync(s => s.SettlementId == settlementId);
            if (settlement == null)
                throw new NotFoundException("Settlement with given id not found");
            if (settlement.UserId != userId)
                throw new ForbidException("You aren't a creator of this settlement");

            var products = await _products.GetAllProductsFromSettlementAsync(settlementId);

            return new SettlementDetailForCreatorDTO
            {
                Products = products,
                SettlementId = settlement.SettlementId,
                Currency=settlement.Currency,
                Amount= products.Sum(p => p.FullPrice)               
            };
        }
    }
}

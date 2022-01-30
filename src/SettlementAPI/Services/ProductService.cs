using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using SettlementAPI.Exceptions;
using SettlementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Options.IdentityOptions _identity;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SettlementDbContext _context;
        
        
        public ProductService(
            IUnitOfWork unitOfWork,
            Options.IdentityOptions identity,
            IMapper mapper,
            UserManager<User> userManager,
            SettlementDbContext context
            )
        {
            _context=context;
            _unitOfWork=unitOfWork;
            _identity=identity;
            _mapper=mapper;
            _userManager=userManager;
        }

        public async Task AddProductToSettlementAsync(ProductToAddDTO product, int settlementId)
        {
            if (product.Quantity < 0)
                throw new ValidationException($"{product.Name} quantity must be greater than 0!", null);
            if (product.FullPrice < 0)
                throw new ValidationException($"{product.Name} price can't be negative!", null);

            var uniqueUsersList = product.UsersWhoTakeProduct.Distinct();
            var userCount = uniqueUsersList.Count();
            var productToAdd = new Product
            {
                Name = product.Name,
                FullPrice = product.FullPrice / userCount,
                Quantity = product.Quantity / userCount
            };

            var settlement = await _context.Settlements.FindAsync(settlementId);
            if (settlement == null)
                throw new NotFoundException($"Settlement with id: {settlementId} not found!");

            if (userCount != 0)
            {
                await _context.Products.AddAsync(productToAdd);
                await _context.SaveChangesAsync();
                settlement.Amount += product.FullPrice;
            }

            
            foreach (var user in uniqueUsersList)
            {      
                    var productSettlementListing = new ProductSettlement()
                    {
                        UserId = user,
                        ProductId = productToAdd.ProductId,
                        SettlementId = settlementId,
                        Currency = settlement.Currency,
                        Amount = productToAdd.FullPrice,
                        Quantity = productToAdd.Quantity
                    };
                    _context.ProductSettlements.Add(productSettlementListing);
                    //settlement.ProductSettlementList.Add(productSettlementListing);      
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductDetailForCreatorDTO>> GetAllProductsFromSettlementAsync(int settlementId)
        {
            var productsIds =await _context.ProductSettlements
                .Where(ps => ps.SettlementId == settlementId)
                .Select(ps => ps.ProductId).Distinct().ToListAsync();
            var productsList = new List<ProductDetailForCreatorDTO>();
            foreach (var productId in productsIds)
            {

            }
        }
    }
}

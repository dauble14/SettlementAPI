using SettlementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface IProductService
    {
        public Task AddProductToSettlementAsync(ProductToAddDTO product, int settlementId);
        Task<List<ProductDetailForCreatorDTO>> GetAllProductsFromSettlementAsync(int settlementId);
    }
}

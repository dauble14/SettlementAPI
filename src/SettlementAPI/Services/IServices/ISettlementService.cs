using SettlementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface ISettlementService
    {
        
        public Task<SettlementDTO> CreateSettlementAsync(List<ProductToAddDTO> productsAndUsers, string currency);
        public void CheckDebt();
        Task<SettlementDetailDTO> GetSettlementDetail(int settlementId);
        Task<SettlementDetailForCreatorDTO> GetSettlementDetailForCreatorAsync(int settlementId);
        Task<List<SettlementOverallDTO>> GetAllSettlementsAsync(string currency, string filter, string sortBy);
        //Task<> GetSettlementAsync(int id);
    }
}

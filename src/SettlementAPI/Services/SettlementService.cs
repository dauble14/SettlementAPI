using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using SettlementAPI.Models;
using SettlementAPI.Options;
using System.Threading.Tasks;
using System.Transactions;

namespace SettlementAPI.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly IdentityOptions _identity;
        private readonly IUnitOfWork _unitOfWork;

        public SettlementService(IdentityOptions identity, IUnitOfWork unitOfWork)
        {
            _identity = identity;
            _unitOfWork = unitOfWork;
        }
        
        public Task<SettlementDTO> CreateAsync(SettlementDTO model)
        {
            using(var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var settlement = new Settlement
                {
                    Amount = model.Amount,
                    Currency = model.Currency,
                    CreatedByUser = _identity.UserId    
                };
            }
        }
    }
}

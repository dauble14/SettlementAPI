using SettlementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface ISettlementService
    {
        public Task<CreateSettlementDTO> CreateAsync(CreateSettlementDTO model);
        public void CheckDebt();
    }
}

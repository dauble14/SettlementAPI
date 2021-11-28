using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IRepositories;
using SettlementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Core.Repositories
{
    public class SettlementRepository : GenericRepository<Settlement> ,ISettlementRepository
    {
        public SettlementRepository(SettlementDbContext context,
            ILogger logger): base(context, logger)
        {

        }
    }
}

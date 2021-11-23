using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IRepositories;
using SettlementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SettlementAPI.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            SettlementDbContext context, 
            ILogger logger
            ) : base(context, logger)
        {
        }

        
    }
}

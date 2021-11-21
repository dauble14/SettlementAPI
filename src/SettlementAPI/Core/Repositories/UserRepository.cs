using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IRepositories;
using SettlementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                var existingUser = await _dbSet.Where( x => x.UserId == entity.UserId ).FirstOrDefaultAsync();

                if (existingUser != null)
                    return await Add(existingUser);

                existingUser.Email = entity.Email;
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                return false;
            }
        }
    }
}

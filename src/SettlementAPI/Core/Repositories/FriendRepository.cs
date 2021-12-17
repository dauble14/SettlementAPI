using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IRepositories;
using SettlementAPI.Entities;

namespace SettlementAPI.Core.Repositories
{
    public class FriendRepository : GenericRepository<Friend>, IFriendRepository
    {
        public FriendRepository(SettlementDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}

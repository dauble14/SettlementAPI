using SettlementAPI.Core.IRepositories;
using System.Threading.Tasks;

namespace SettlementAPI.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        //IUserRepository Users { get; }
        ISettlementRepository Settlements {get;}
        IFriendRepository Friends {get;}
        Task CompleteAsync();
    }
}

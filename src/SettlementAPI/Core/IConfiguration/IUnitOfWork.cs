using SettlementAPI.Core.IRepositories;
using System.Threading.Tasks;

namespace SettlementAPI.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        //IUserRepository Users { get; }
        Task CompleteAsync();
    }
}

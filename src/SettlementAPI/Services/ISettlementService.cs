using SettlementAPI.Models;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface ISettlementService
    {
        Task<SettlementDTO> CreateAsync(SettlementDTO settlement);
    }
}

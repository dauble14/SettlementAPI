using SettlementAPI.Models;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}

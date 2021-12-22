using SettlementAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface IFriendService
    {
        Task<string> GetUserFriendInvitationCode();
        Task<bool> AddFriendByHisInvitationCode(string invitationCode);
        Task<string> GenerateFriendInvitationCode();
        Task<List<UserFriendDTO>> GetUserFriendsAsync();
    }
}

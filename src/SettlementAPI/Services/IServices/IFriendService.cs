using SettlementAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface IFriendService
    {
        Task<string> GetUserFriendInvitationCode();
        Task<UserFriendDTO> AddFriendByHisInvitationCode(string invitationCode);
        Task<string> GenerateFriendInvitationCode();
        Task<List<UserFriendDTO>> GetUserFriendsAsync();
        Task DeleteUserFriend(string friendId);
        Task<bool> IsUserFriend(string friendId);
    }
}

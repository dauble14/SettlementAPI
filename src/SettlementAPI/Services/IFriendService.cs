using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public interface IFriendService
    {
        //Task<string> GenerateFriendInvitationCode();
        Task<string> GetUserFriendInvitationCode();

        Task<bool> AddFriendByHisInvitationCode(string invitationCode);
    }
}

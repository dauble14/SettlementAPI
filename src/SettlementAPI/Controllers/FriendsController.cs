using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementAPI.Services;
using System.Threading.Tasks;

namespace SettlementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendService _friends;
        public FriendsController(IFriendService friends)
        {
            _friends = friends;
        }
        
        [HttpGet("invitationcode")]
        public async Task<IActionResult> GetInvitationCode()
        {
            var invitationCode = await _friends.GetUserFriendInvitationCode();
            return Ok(invitationCode);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFriends()
        {
            var friends = await _friends.GetUserFriendsAsync();
            return Ok(friends);
        }

        [Route("add/{invitationCode}")]
        [HttpPut]
        public async Task<IActionResult> AddFriendByInvitationCode(string invitationCode)
        {
            await _friends.AddFriendByHisInvitationCode(invitationCode);
            return Ok("Succesfully added user to friends");
        }


    }
}

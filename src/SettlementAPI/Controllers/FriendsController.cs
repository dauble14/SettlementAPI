using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementAPI.Models.DTO;
using SettlementAPI.Models.Responses;
using SettlementAPI.Services;
using System.Collections.Generic;
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
        
        [ProducesResponseType(200, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpGet("invitationcode")]
        public async Task<IActionResult> GetInvitationCode()
        {
            var invitationCode = await _friends.GetUserFriendInvitationCode();
            return Ok(new ApiResponse<string>(invitationCode, "Successfully obtaianed user invitation code"));
        }

        [ProducesResponseType(200, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpGet("invitationcode/generatenew")]
        public async Task<IActionResult> GenerateNewInvitationCode()
        {
            var newInvitationCode = await _friends.GenerateFriendInvitationCode();
            return Ok(new ApiResponse<string>(newInvitationCode, "Successfully generated new user invitation code"));
        }

        [ProducesResponseType(200, Type = typeof(ApiResponse<List<UserFriendDTO>>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpGet]
        public async Task<IActionResult> GetAllFriends()
        {
            var friends = await _friends.GetUserFriendsAsync();
            return Ok(new ApiResponse<List<UserFriendDTO>>(friends, "Successfully obtained user friends"));
        }

        [ProducesResponseType(200, Type = typeof(ApiResponse))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [Route("add/{invitationCode}")]
        [HttpPut]
        public async Task<IActionResult> AddFriendByInvitationCode(string invitationCode)
        {
            var friendUser =  await _friends.AddFriendByHisInvitationCode(invitationCode);
            return Ok(new ApiResponse($"Succesfully added {friendUser.FirstName} {friendUser.LastName} to friends"));
        }

        [ProducesResponseType(200, Type = typeof(ApiResponse))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpDelete("{friendId}")]
        public async Task<IActionResult> DeleteFriend(string friendId)
        {
            await _friends.DeleteUserFriend(friendId);
            return Ok(new ApiResponse("Friend deleted successfully!"));
        }


    }
}

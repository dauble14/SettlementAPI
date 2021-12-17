using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Options.IdentityOptions _identity;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public FriendService(
                IUnitOfWork unitOfWork,
                Options.IdentityOptions identity,
                IMapper mapper,
                UserManager<User> userManager
            )
        {
            _identity=identity;
            _unitOfWork=unitOfWork;
            _mapper=mapper;
            _userManager=userManager;
        }

        public async Task<bool> AddFriendByHisInvitationCode(string invitationCode)
        {
            var loggedUserMail = _identity.UserMail;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserMail);
            var friendToAdd = _userManager.Users.FirstOrDefault(x=>x.FriendIdCode==invitationCode);
            if (friendToAdd == null)
                return false; //friend with given invitation code not found

            var relationship= await _unitOfWork.Friends.Get(x => x.UserId == loggedUser.Id && x.FriendUserId == friendToAdd.Id);
            if (relationship != null)
                return false; //they are already friends

            var friendshipToAdd = new Friend()
            {
                UserId = loggedUser.Id,
                FriendUserId = friendToAdd.Id,
                RequestTime = DateTime.Now,
                FriendRequestFlag = FriendRequestFlag.Approved
             };
            await _unitOfWork.Friends.Insert(friendshipToAdd);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<string> GetUserFriendInvitationCode()
        {
            var userMail = _identity.UserMail;
            var user = await _userManager.FindByNameAsync(userMail);
            if(user.FriendIdCode!=null)
                return user.FriendIdCode;

            return await GenerateFriendInvitationCode();
        }

        private async Task<string> GenerateFriendInvitationCode()
        {
            var userMail = _identity.UserMail;
            var user = await _userManager.FindByNameAsync(userMail);
            var allUsersInvitationCode = await _userManager.Users.Select(x => x.FriendIdCode).ToListAsync();

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;

            do
            {
                for (int i = 0; i < 7; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);
                }
            } while (allUsersInvitationCode.Contains(str_build.ToString()));
            

            user.FriendIdCode = str_build.ToString();
            await _userManager.UpdateAsync(user);
            return user.FriendIdCode;
        }


    }
}

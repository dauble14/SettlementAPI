using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using SettlementAPI.Exceptions;
using SettlementAPI.Models.DTO;
using System;
using System.Collections.Generic;
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
        private readonly SettlementDbContext _context;
        public FriendService(
                IUnitOfWork unitOfWork,
                Options.IdentityOptions identity,
                IMapper mapper,
                UserManager<User> userManager,
                SettlementDbContext context
            )
        {
            _identity=identity;
            _unitOfWork=unitOfWork;
            _mapper=mapper;
            _userManager=userManager;
            _context=context;
        }

        public async Task<UserFriendDTO> AddFriendByHisInvitationCode(string invitationCode)
        {
            var loggedUserMail = _identity.UserMail;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserMail);
            var friendToAdd = _userManager.Users.FirstOrDefault(x=>x.FriendIdCode==invitationCode);
            if (friendToAdd == null)
                throw new NotFoundException($"User with friend code: {invitationCode} not found");

            if (loggedUser.Id == friendToAdd.Id)
                throw new AlreadyExistsException("You cannot add yourself!");

            var relationship= await _unitOfWork.Friends.Get(x => ((x.UserId == loggedUser.Id && x.FriendUserId == friendToAdd.Id) ||
                (x.UserId == friendToAdd.Id && x.FriendUserId == loggedUser.Id))); //wiem okropnie to wyglada
            if (relationship != null)
                throw new AlreadyExistsException($"Already friends!");

            var friendshipToAdd = new Friend()
            {
                UserId = loggedUser.Id,
                FriendUserId = friendToAdd.Id,
                RequestTime = DateTime.Now,
                FriendRequestFlag = FriendRequestFlag.Approved
             };

            var friendshipToAdd2 = new Friend()
            {
                UserId = friendToAdd.Id,
                FriendUserId = loggedUser.Id,
                RequestTime = DateTime.Now,
                FriendRequestFlag = FriendRequestFlag.Approved
            };
            await _unitOfWork.Friends.Insert(friendshipToAdd);
            await _unitOfWork.Friends.Insert(friendshipToAdd2);
            
            await _unitOfWork.CompleteAsync();

            var friendToAddDTO = _mapper.Map<User, UserFriendDTO>(friendToAdd);
            return friendToAddDTO;
        }

        public async Task DeleteUserFriend(string friendId)
        {
            var loggedUserMail = _identity.UserMail;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserMail);
            var friendToDelete = await _userManager.Users.FirstOrDefaultAsync(x => x.Id==friendId);
            if (friendId == loggedUser.Id)
                throw new NotFoundException("You cannot delete yourself!");
            
            if (friendToDelete == null)
                throw new NotFoundException($"User with given id not found");

            var friendshipToDelete = await _unitOfWork.Friends.Get(x => x.UserId == loggedUser.Id && x.FriendUserId==friendId);
            var friendshipToDelete2 = await _unitOfWork.Friends.Get(x => x.UserId == friendId && x.FriendUserId==loggedUser.Id);
            if (friendshipToDelete == null || friendshipToDelete2 == null)
                throw new NotFoundException("You aren't friends!");

            await _unitOfWork.Friends.Delete(friendshipToDelete.Id);
            await _unitOfWork.Friends.Delete(friendshipToDelete2.Id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<string> GetUserFriendInvitationCode()
        {
            var userMail = _identity.UserMail;
            var user = await _userManager.FindByNameAsync(userMail);
            if(user.FriendIdCode!=null)
                return user.FriendIdCode;

            return await GenerateFriendInvitationCode();
        }

        public async Task<string> GenerateFriendInvitationCode()
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

        public async Task<List<UserFriendDTO>> GetUserFriendsAsync()
        {
            var loggedUserMail = _identity.UserMail;
            var loggedUser = await _userManager.FindByNameAsync(loggedUserMail);
            
            var userFriends = await _context.Friends.Where(x => x.UserId == loggedUser.Id).Include(x=>x.FriendUser).Select(x=>x.FriendUser).ToListAsync();

            var userFriendsDTO = _mapper.Map<List<User>, List<UserFriendDTO>>(userFriends);
            
            return userFriendsDTO;
        }

        public async Task<bool> IsUserFriend(string friendId)
        {
            var loggedUserId = _identity.UserId;
            return await _context.Friends.AnyAsync(f => (f.UserId == loggedUserId && f.FriendUserId == friendId) || (f.UserId == friendId && f.FriendUserId == loggedUserId));
        }
    }
}

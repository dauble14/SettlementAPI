using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SettlementAPI.Entities;
using SettlementAPI.Exceptions;
using SettlementAPI.Models.DTO;
using SettlementAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public class MoneyTransferService : IMoneyTransferService
    {
        private readonly Options.IdentityOptions _identity;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SettlementDbContext _context;
        private readonly IFriendService _friends;

        public MoneyTransferService(
            Options.IdentityOptions identity,
            IMapper mapper,
            UserManager<User> userManager,
            SettlementDbContext context,
            IFriendService friends)
        {
            _identity = identity;
            _mapper = mapper;
            _userManager = userManager;
            _friends = friends;
            _context = context;
        }

        public async Task SendMoneyTransferAsync(string receiverId, string currency, double amount)
        {
            var loggedUserId = _identity.UserId;
            var approximatedAmount = Math.Round(amount*100, 0);
            if (amount <= 0 || ((approximatedAmount-amount*100)!=0))
                throw new ValidationException("Invalid amount value", null);
            if (receiverId == loggedUserId)
                throw new ValidationException("You can't transfer money to yourself", null);
            
            if (!(await _friends.IsUserFriend(receiverId)))
                throw new ForbidException("User with given id isn't your friend");
            

            await _context.MoneyTransfers.AddAsync(new MoneyTransfer
            {
                SenderId=loggedUserId,
                ReceiverId=receiverId,
                Currency=currency,
                Amount=amount,
                TransferRequestFlag=TransferRequestFlag.None,
                SendedAtTime=DateTime.Now
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<MoneyTransferDTO>> GetMoneyTransfersAsync(string filter)
        {
            var loggedUserId = _identity.UserId;
            var moneyTransfers = await _context.MoneyTransfers
                .Where(mt => mt.ReceiverId == loggedUserId).OrderByDescending(mt=>mt.SendedAtTime).ToListAsync();

            switch (filter)
            {
                case "pending":
                    moneyTransfers = moneyTransfers.Where(mt => mt.TransferRequestFlag == TransferRequestFlag.None).ToList();
                    break;

                case "accepted":
                    moneyTransfers = moneyTransfers.Where(mt => mt.TransferRequestFlag == TransferRequestFlag.Accepted).ToList();
                    break;

                case "rejected":
                    moneyTransfers = moneyTransfers.Where(mt => mt.TransferRequestFlag == TransferRequestFlag.Rejected).ToList();
                    break;
                default:
                    break;
            }

            var pendingMoneyTransferDTOList = new List<MoneyTransferDTO>();
            foreach (var moneyTransfer in moneyTransfers)
            {
                var senderUser =await _userManager.FindByIdAsync(moneyTransfer.SenderId);
                pendingMoneyTransferDTOList.Add(new MoneyTransferDTO 
                {
                    Id= moneyTransfer.Id,
                    SenderId=moneyTransfer.SenderId,
                    SenderFirstName=senderUser.FirstName,
                    SenderLastName=senderUser.LastName,
                    Amount=moneyTransfer.Amount,
                    Currency=moneyTransfer.Currency,
                    SendedAtTime=moneyTransfer.SendedAtTime,
                    TransferRequestFlag= moneyTransfer.TransferRequestFlag
                });
            }

            return pendingMoneyTransferDTOList;
        }

        public async Task SetTransferStatus(int transferId, TransferResponseAction action)
        {
            var loggedUserId = _identity.UserId;
            var transfer= await _context.MoneyTransfers.FirstOrDefaultAsync(mt=>mt.Id==transferId);
            if(transfer == null)
                throw new NotFoundException("Transfer with given id not found");
            if (transfer.ReceiverId != loggedUserId)
                throw new ForbidException("User are not the receiver of the transfer");
            switch (action)
            {
                case TransferResponseAction.Reject:
                    if (transfer.TransferRequestFlag == TransferRequestFlag.Accepted)
                        throw new ForbidException("Transaction alredy rejected");
                    transfer.TransferRequestFlag = TransferRequestFlag.Rejected;
                    break;

                case TransferResponseAction.Accept:
                    if (transfer.TransferRequestFlag == TransferRequestFlag.Rejected)
                        throw new ForbidException("Transaction alredy accepted");
                    transfer.TransferRequestFlag = TransferRequestFlag.Accepted;
                    break;

                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }
    }
}

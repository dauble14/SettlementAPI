using SettlementAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Services.IServices
{
    public interface IMoneyTransferService
    {
        Task SendMoneyTransferAsync(string receiverId, string currency, double amount);
        Task<List<MoneyTransferDTO>> GetMoneyTransfersAsync(string filter);
        Task SetTransferStatus(int statusId, TransferResponseAction action);
        Task<List<CashBalanceDTO>> GetAllCashBalancesWithUsersAsync(string currency);

        Task<CashBalanceDTO> GetMoneyTransferBalanceBetweenUsersAsync(string userId);

        Task<List<string>> GetAllUsersRelatedToTheMoneyExchangeWithTheUserAsync(string userId);
    }
}

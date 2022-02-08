using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementAPI.Models.DTO;
using SettlementAPI.Models.Responses;
using SettlementAPI.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettlementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        private readonly IMoneyTransferService _transfers;
        public TransfersController(IMoneyTransferService transfers)
        {
            _transfers = transfers;
        }

        [HttpPost]
        public async Task<IActionResult> SendMoneyTransfer([FromBody] TransferDTO TransferDTO)
        {
            if (TransferDTO.Currency == null)
                TransferDTO.Currency = "PLN";
            await _transfers.SendMoneyTransferAsync(TransferDTO.ReceiverId, TransferDTO.Currency, TransferDTO.Amount);
            return Ok(new ApiResponse("Succesfully sended money to user"));
        }

        [HttpGet]
        public async Task<IActionResult> GetTransfers(string filter)
        {
            var transfers =await _transfers.GetMoneyTransfersAsync(filter);

            return Ok(new ApiResponse<List<MoneyTransferDTO>>(transfers, $"Successfully retrived {filter} user transfers"));
        }
 
        [HttpPut("{transferId}/{actionString}")]
        public async Task<IActionResult> ResponseToTransfer(int transferId, string actionString)
        {
            switch (actionString)
            {
                case "accept":
                    await _transfers.SetTransferStatus(transferId, TransferResponseAction.Accept);
                    break;
                case "reject":
                    await _transfers.SetTransferStatus(transferId, TransferResponseAction.Reject);
                    break;
                default:
                    return BadRequest("Invalid response action");
            }
            return Ok(new ApiResponse($"Successfully {actionString}ed money transfer"));
        }
    }
}

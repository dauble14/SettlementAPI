using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementAPI.Models.DTO;
using SettlementAPI.Models.Responses;
using SettlementAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettlementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BalancesController : ControllerBase
    {
        private readonly IMoneyTransferService _moneyTransferService;
        public BalancesController(IMoneyTransferService moneyTransferService)
        {
            _moneyTransferService=moneyTransferService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllInvoledUsersAndTherBalances(string currency=null)
        {
            var balances =await _moneyTransferService.GetAllCashBalancesWithUsersAsync(currency);
            return Ok(new ApiResponse<List<CashBalanceDTO>>(balances, "Retrieved cash balances between logged user and users involed in money exchange"));
        }
    }
}

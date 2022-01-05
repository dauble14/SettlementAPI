using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementAPI.Models;
using SettlementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Controllers
{
    
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettlementsController : ControllerBase
    {
        private readonly ISettlementService _settlements;
        public SettlementsController(ISettlementService settlements)
        {
            _settlements = settlements;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateSettlement([FromBody] List<ProductToAddDTO> model, string currency="PLN")
        {
            var settlement = await _settlements.CreateSettlementAsync(model, currency);

            return Ok(settlement);
        }

        [HttpGet()] 
        public async Task<IActionResult> GetAllSettlements()
        {
            var settlements = await _settlements.GetAllSettlements();
            return Ok(settlements);    
        }
    }
}

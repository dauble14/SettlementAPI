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
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SettlementsController : ControllerBase
    {
        private readonly ISettlementService _settlements;
        public SettlementsController(ISettlementService settlements)
        {
            _settlements = settlements;
        }
        
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateSettlementDTO model)
        {
            var result = await _settlements.CreateAsync(model);

            return Ok(result);
        }

        [HttpGet()] 
        public IActionResult Debt()
        {
            _settlements.CheckDebt();
            return Ok();    
        }
    }
}

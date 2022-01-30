using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementAPI.Models;
using SettlementAPI.Models.Responses;
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

        [ProducesResponseType(200, Type = typeof(ApiResponse<SettlementDTO>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost]
        public async Task<IActionResult> CreateSettlement([FromBody] List<ProductToAddDTO> model, string currency="PLN")
        {
            var settlement = await _settlements.CreateSettlementAsync(model, currency);

            return Ok(settlement);
        }

        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SettlementOverallDTO>>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpGet]
        public async Task<IActionResult> GetAllSettlements(string filter, string sortBy, string currency="PLN")
        {
            var settlements = await _settlements.GetAllSettlementsAsync(currency, filter, sortBy);
            return Ok(new ApiResponse<List<SettlementOverallDTO>>(settlements, "Retrieved user's settlements"));    
        }

        [ProducesResponseType(200, Type = typeof(ApiResponse<SettlementDetailDTO>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpGet("{settlementId}")]
        public async Task<IActionResult> GetSettlementMemberDetail(int settlementId)
        {
            var settlement = await _settlements.GetSettlementDetail(settlementId);
            return Ok(new ApiResponse<SettlementDetailDTO>(settlement, "Retrieved user's settlement"));
        }

        [HttpGet("{settlementId}/creatorview")]
        public async Task<IActionResult> GetSettlementCreatorDetail(int settlementId)
        {
            var settlement = await _settlements.GetSettlementDetailForCreatorAsync(settlementId);
            return Ok(new ApiResponse<SettlementDetailForCreatorDTO>(settlement, "Retrieved user's settlement detail for creator"));
        }
    }
}

﻿using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
        private readonly ISettlementService _settlements;
        public SettlementController(ISettlementService settlements)
        {
            _settlements = settlements;
        }
        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateSettlementDTO model)
        {
            var result = await _settlements.CreateAsync(model);

            return Ok(result);
        }
    }
}

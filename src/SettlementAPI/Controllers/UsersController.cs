using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using System.Threading.Tasks;
using System;
using AutoMapper;
using SettlementAPI.Models;
using System.Collections.Generic;

namespace SettlementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateUser(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _unitOfWork.Users.Insert(user);
        //            await _unitOfWork.CompleteAsync();
        //            //return CreatedAtAction("GetItem", new { user.UserId }, user);
        //            return Ok(user);
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest("dupa ");                    
                    
        //        }
        //    }

        //    return new JsonResult("Something went wrong") { StatusCode = 500 };
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetUsers()
        //{
        //    try
        //    {
        //        var users = await  _unitOfWork.Users.GetAll();
        //        var results = _mapper.Map<IList<UserDTO>>(users);
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetUsers)}");
        //        return StatusCode(500, "Internal Server Error. Please Try Again Later.");
                
        //    }
        //}


    }
}

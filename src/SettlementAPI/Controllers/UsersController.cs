using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using System.Threading.Tasks;

namespace SettlementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Users.Add(user);
                    await _unitOfWork.CompleteAsync();
                    //return CreatedAtAction("GetItem", new { user.UserId }, user);
                    return Ok(user);
                }
                catch (System.Exception ex)
                {
                    return BadRequest("dupa");                    
                    
                }

                
                
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
    }
}

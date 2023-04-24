using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using task1.Data.Models;
using task1.Dto;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public DataController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]   
        public async Task<ActionResult> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(new { Name = user.UserName, Email = user.Email, Position = user.Position });
        }

        [HttpGet("Admin")]
       
        [Authorize(policy: "AllowAdmin")]

        public async Task<ActionResult> GetInfoForManager()
        {
            
            return Ok(new { Data = "This data is Authorize for Admin" });
        }


        [HttpGet("User")]
        
        [Authorize(policy: "AllowUser")]

        public async Task<ActionResult> GetInfoForUser()
        {

            return Ok(new { Data = "This data is Authorize for Admin & User" });
        }



    }
}

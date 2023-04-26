using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using task1.API.Data.Models;
using task1.API.Dto;

namespace task1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserController(IConfiguration configuration,
            UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto Data)
        {
            var user = await _userManager.FindByEmailAsync(Data.Email!);
            if (user == null)
            {
                return NotFound();
            }
            var isAuthenitcated = await _userManager.CheckPasswordAsync(user, Data.Password!);
            if (!isAuthenitcated)
            {
                return Unauthorized();
            }

            var claimsList = await _userManager.GetClaimsAsync(user);



            return Ok(GetUserToken(claimsList));
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<TokenDto>> Register(RegisterDto Data)
        {
            var userToAdd = new User
            {
                UserName = Data.Name,
                Email = Data.Email,
                PhoneNumber = Data.Phone,
                Position = Data.Position
            };

            var result = await _userManager.CreateAsync(userToAdd, Data.Pass);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            string role = "Instructor";

            if (Data.Secret == _configuration.GetValue<string>("Secret"))
                role = "Admin";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userToAdd.Id),
                new Claim(ClaimTypes.Role, role)
            };

            await _userManager.AddClaimsAsync(userToAdd, claims);

            return Ok(GetUserToken(claims));
        }


        [NonAction]
        private string GetUserToken(IEnumerable<Claim> claimsList)
        {
            var secretKeyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

            //Combination SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(1);//expire of token 1Day

            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiry,
                signingCredentials: siginingCreedentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);//convert token to string

            return tokenString;
        }
    }
}

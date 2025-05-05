using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI_JWT.Models;
using WebAPI_JWT.Models.DTO;

namespace WebAPI_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> LoginProcess(LoginDTO login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if(user == null)            
                return Unauthorized();
            

            var IsPasswordCorrect = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!IsPasswordCorrect)            
                return Unauthorized();
            
            // Token oluştur ve geriye gönder
            return Ok(GetToken(user.Email));
        }

        private string GetToken(string email)
        {
            var authClaims = new List<Claim> { new Claim(ClaimTypes.Email, email) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:secretKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                authClaims.ToString(),
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

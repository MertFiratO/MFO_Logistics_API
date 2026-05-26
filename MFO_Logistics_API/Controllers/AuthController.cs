using MFO_Logistics_API.Data;
using MFO_Logistics_API.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MFO_Logistics_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<ReportsController> _logger;

        private readonly AppDbContext _context;

        public AuthController(IConfiguration configuration , ILogger<ReportsController> logger , AppDbContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var user = await _context.Users
    .FirstOrDefaultAsync(x =>
        x.UserLogin == request.Username &&
        x.UserPassword == request.Password &&
        x.IsActive == 1);

            if (user == null)
            {
                return Unauthorized();
            }

            _logger.LogInformation("Authorize verildi.");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            _logger.LogInformation($"Token : {token} ");

            return Ok(new
            {

                token = new JwtSecurityTokenHandler().WriteToken(token)

            });
        }

    }
}

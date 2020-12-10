using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeStamp.Application.Interfaces;
using TimeStamp.Infrastructure.Configurations;

namespace TimeStamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IOptions<Settings> _settings;
        private readonly IAuthenticationApp _authenticationApp;

        public TokenController(IOptions<Settings> settings, IAuthenticationApp authenticationApp)
        {
            _settings = settings;
            _authenticationApp = authenticationApp;
        }

        [HttpPost]
        public IActionResult Create(string email, string password)
        {
            if (CombinationUserPasswordValid(email, password))
                return new ObjectResult(GenerateToken(email));

            return BadRequest();
        }

        private bool CombinationUserPasswordValid(string email, string password) 
            => !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && _authenticationApp.Authorize(email, password);

        private string GenerateToken(string email)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.SecretKey)),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
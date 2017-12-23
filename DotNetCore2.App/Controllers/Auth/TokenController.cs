using DotNetCore2.EF.Commands;
using DotNetCore2.Model.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore2.Controllers.Auth
{
    [Route("api/token")]
    public class TokenController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOptions<Audience> _settings;

        public TokenController(UserManager<IdentityUser> userManager,
            IOptions<Audience> settings)
        {
            _userManager = userManager;
            _settings = settings;
        }

        [HttpGet()]
        public IActionResult GetToken([FromQuery]UserDetails token)
        {
            if (token == null)
            {
                return BadRequest("Invalid parameters");
            }

            if (token.GrantType == "password")
            {
                return Ok(Json(Authorize(token)));
            }
            else
            {
                return BadRequest("Invalid grant type");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        private async Task<Authentication> Authorize(UserDetails userDetails)
        {
            var identUser = await _userManager.FindByNameAsync(userDetails.Username);

            var isValidated = await _userManager.CheckPasswordAsync(identUser, userDetails.Password);

            if (!isValidated)
            {
                throw new ArgumentException("Invalid parameters");
            }

            var token = GetToken();

            var authentication = new Authentication()
            {
                Username = userDetails.Username,
                Token = token.value,
                Expires = token.expiry
            };

            return authentication;
        }

        private (string value, int expiry) GetToken()
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "123123"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            var symmetricKeyAsBase64 = _settings.Value.Secret;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var jwt = new JwtSecurityToken(
                issuer: _settings.Value.Iss,
                audience: _settings.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (encodedJwt, (int)TimeSpan.FromMinutes(2).TotalSeconds);
        }
    }
}

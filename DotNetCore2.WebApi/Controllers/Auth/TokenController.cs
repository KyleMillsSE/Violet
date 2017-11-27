using DotNetCore2.EF.Commands;
using DotNetCore2.Models.Domain;
using DotNetCore2.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly IAuthTokenInsertCommand _authTokenInsertCommand;

        public TokenController(UserManager<IdentityUser> userManager,
            IOptions<Audience> settings,
            IAuthTokenInsertCommand authTokenInsertCommand)
        {
            _userManager = userManager;
            _settings = settings;
            _authTokenInsertCommand = authTokenInsertCommand;
        }

        [HttpGet()]
        public IActionResult GetToken([FromQuery]dynamic parameters)
        {
            if (parameters == null)
            {
                return BadRequest("Invalid parameters");
            }

            if (parameters.grant_type == "password")
            {
                return Ok(Json(Authorize(parameters)));
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
        private async Task<string> Authorize(dynamic parameters)
        { 
            var identUser = await _userManager.FindByEmailAsync(parameters.username);

            var isValidated = await _userManager.CheckPasswordAsync(identUser, parameters.password);

            if (!isValidated)
            {
                throw new ArgumentException("Invalid parameters");
            }

            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");

            var rToken = new AuthToken
            {
                ClientId = parameters.client_id,
                RefreshToken = refresh_token,
                IsStop = false
            };

            await _authTokenInsertCommand.ExecuteAsync(rToken);

            return GetJwt(parameters.client_id, refresh_token);
        }

        private string GetJwt(string client_id, string refresh_token)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, client_id),
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
                expires: now.Add(TimeSpan.FromMinutes(1)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)TimeSpan.FromMinutes(2).TotalSeconds,
                refresh_token = refresh_token,
            };

            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}

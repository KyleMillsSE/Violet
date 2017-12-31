using DotNetCore2.EF.Queries.Contracts;
using DotNetCore2.Model.Domain.Auth;
using DotNetCore2.Model.Domain.User;
using DotNetCore2.Model.Domain.Utils;
using DotNetCore2.Model.Entities;
using DotNetCore2.Services.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
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
        private readonly ICoreGetAllQuery<CoreUser> _userQuery;
        private readonly IOptions<Audience> _settings;

        public TokenController(ICoreGetAllQuery<CoreUser> userQuery, IOptions<Audience> settings)
        {
            _userQuery = userQuery;
            _settings = settings;
        }

        [HttpGet()]
        public IActionResult GetToken([FromQuery]UserLoginDto user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid parameters");
                }

                if (user.GrantType == "password")
                {
                    return Ok(Authorize(user));
                }
                else
                {
                    return BadRequest("Invalid grant type");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid parameters");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        private AuthenticationDto Authorize(UserLoginDto user)
        {
            var identUser = _userQuery.Execute().FirstOrDefault(u => u.Username == user.Username);

            if (identUser == null)
            {
                throw new ArgumentException("Invalid parameters");
            }

            var isValidated = CryptoHelperWrapper.VerifyPassword(identUser.Password, user.Password);

            if (!isValidated)
            {
                throw new ArgumentException("Invalid parameters");
            }

            var token = GetToken(identUser.Id.ToString());

            var authentication = new AuthenticationDto()
            {
                Username = user.Username,
                Token = token.value,
                Expires = token.expiry
            };

            return authentication;
        }

        private (string value, int expiry) GetToken(string userId)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim("UniqueUserIndentifier", userId)
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

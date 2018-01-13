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
            if (user?.GrantType == "password")
                return Ok(Authorize(user));
            else
                return BadRequest("Invalid parameters");
        }

        [HttpPost]
        public IActionResult RefreshToken([FromQuery]string expiredToken)
        {
            var decodedExpiredToken = new JwtSecurityToken(expiredToken);

            if (decodedExpiredToken.Issuer != _settings.Value.Iss)
                return BadRequest("Invalid iss");

            //additional checks if you want to be more strict

            var UniqueUserIndentifier = decodedExpiredToken.Claims.FirstOrDefault(t => t.Type == "UniqueUserIndentifier");
            if (UniqueUserIndentifier == null)
                return BadRequest("Invalid token");

            var (refreshedToken, refreshedExpiry) = GetToken(UniqueUserIndentifier.Value);

            var auth = new AuthenticationDto()
            {
                Token = refreshedToken,
                Expires = refreshedExpiry
            };

            return Ok(auth);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        private AuthenticationDto Authorize(UserLoginDto user)
        {
            var identUser = _userQuery.Execute().FirstOrDefault(u => u.Username == user.Username);
            if (identUser == null)
                throw new ArgumentException("Invalid parameters");

            var isValidated = CryptoHelperWrapper.VerifyPassword(identUser.Password, user.Password);
            if (!isValidated)
                throw new ArgumentException("Invalid parameters");

            var (token, expiry) = GetToken(identUser.Id.ToString());

            return new AuthenticationDto()
            {
                Username = user.Username,
                Token = token,
                Expires = expiry
            };
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
                expires: now.Add(TimeSpan.FromMinutes(1)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (encodedJwt, (int)TimeSpan.FromMinutes(1).TotalSeconds);
        }
    }
}

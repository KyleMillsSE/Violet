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
        private readonly ICoreGetAllQuery<CoreUser> _userGetAllQuery;
        private readonly ICoreGetByIdQuery<CoreUser> _userGetByIdQuery;
        private readonly IOptions<Audience> _authSettings;

        public TokenController(ICoreGetAllQuery<CoreUser> userGetAllQuery, ICoreGetByIdQuery<CoreUser> userGetByIdQuery, IOptions<Audience> authSettings)
        {
            _userGetAllQuery = userGetAllQuery;
            _userGetByIdQuery = userGetByIdQuery;
            _authSettings = authSettings;
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

            //additional checks if you want to be more strict
            if (decodedExpiredToken.Issuer != _authSettings.Value.Iss)
                return BadRequest("Invalid parameters");

            var UniqueUserIndentifier = decodedExpiredToken.Claims.FirstOrDefault(t => t.Type == "UniqueUserIndentifier");
            if (UniqueUserIndentifier == null)
                return BadRequest("Invalid parameters");

            var user = _userGetByIdQuery.Execute(Guid.Parse(UniqueUserIndentifier.Value));
            if (user == null)
                return BadRequest("Invalid parameters");

            var (refreshedToken, refreshedExpiry) = GetToken(user.Id.ToString());

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
        private AuthenticationDto Authorize(UserLoginDto userLogin)
        {
            var user = _userGetAllQuery.Execute().FirstOrDefault(u => u.Username == userLogin.Username);
            if (user == null)
                throw new ArgumentException("Invalid parameters");

            var isValidated = CryptoHelperWrapper.VerifyPassword(user.Password, user.Password);
            if (!isValidated)
                throw new ArgumentException("Invalid parameters");

            var (token, expiry) = GetToken(user.Id.ToString());

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

            var symmetricKeyAsBase64 = _authSettings.Value.Secret;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var jwt = new JwtSecurityToken(
                issuer: _authSettings.Value.Iss,
                audience: _authSettings.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(1)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (encodedJwt, (int)TimeSpan.FromMinutes(1).TotalSeconds);
        }
    }
}

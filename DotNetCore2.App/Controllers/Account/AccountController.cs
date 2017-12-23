using DotNetCore2.Model.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.App.Controllers.Account
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private static UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserDetails newUser)
        {
            var user = new IdentityUser() { Email = newUser.Email, UserName = newUser.Username };

            var userCreated = await _userManager.CreateAsync(user, newUser.Password);

            if (!userCreated.Succeeded)
            {
                return BadRequest(GetErrors(userCreated.Errors));
            }

            return Ok();
        }

        private string GetErrors(IEnumerable<IdentityError> errors)
        {
            return errors.FirstOrDefault()?.Description;
        }
    }
}

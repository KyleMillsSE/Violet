using DotNetCore2.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DotNetCore2.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserDetails newUser)
        {
            var user = new IdentityUser() { Email = newUser.Email, UserName = newUser.Email };

            var userCreated = await _userManager.CreateAsync(user);

            if (!userCreated.Succeeded)
            {
                return BadRequest(GetErrors(userCreated.Errors));
            }

            var passwordCreated = await _userManager.AddPasswordAsync(user, newUser.Password);

            if (!passwordCreated.Succeeded)
            {
                await _userManager.DeleteAsync(user);
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

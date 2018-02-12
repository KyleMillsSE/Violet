using DotNetCore2.EF.Queries;
using DotNetCore2.Model;
using DotNetCore2.Model.Domain.User;
using DotNetCore2.Model.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetCore2.Controllers.Users
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly ICoreGetAllQuery<CoreUser> _userQuery;

        public UsersController(ICoreGetAllQuery<CoreUser> userQuery)
        {
            _userQuery = userQuery;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers() => Ok(_userQuery.Execute().ToList().Select(x => x.MapTo<UserDto>()));

    }
}

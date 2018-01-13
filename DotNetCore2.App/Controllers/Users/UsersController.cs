using DotNetCore2.App.SignalR;
using DotNetCore2.EF.Queries.Contracts;
using DotNetCore2.Model;
using DotNetCore2.Model.Domain.User;
using DotNetCore2.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Controllers.Users
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly ICoreGetAllQuery<CoreUser> _userQuery;

        public UsersController(ICoreGetAllQuery<CoreUser> userQuery
        {
            _userQuery = userQuery;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var users = _userQuery.Execute().ToList().Select(x => x.MapTo<UserDto>());

            return Ok(users);
        }
    }
}

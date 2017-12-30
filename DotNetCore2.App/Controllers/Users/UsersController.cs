using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore2.Controllers.Users
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        public UsersController()
        {
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.App.Controllers.Test
{
    [Route("api/test")]
    public class TestController : Controller
    {
        public TestController()
        {

        }


        [HttpGet()]
        [Authorize]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}

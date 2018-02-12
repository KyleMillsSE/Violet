using DotNetCore2.EF.Queries;
using DotNetCore2.Model;
using DotNetCore2.Model.Domain.SecurityProfile;
using DotNetCore2.Model.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetCore2.App.Controllers.SecurityProfiles
{
    [Authorize]
    [Route("api/securityprofiles")]
    public class SecurityProfilesController : Controller
    {
        private readonly ICoreGetAllQuery<CoreSecurityProfile> _securityProfileQuery;

        public SecurityProfilesController(ICoreGetAllQuery<CoreSecurityProfile> securityProfileQuery) => _securityProfileQuery = securityProfileQuery;



        [HttpGet]
        public IActionResult Get() => Ok(_securityProfileQuery.Execute().ToList().Select(x => x.MapTo<SecurityProfileDto>()));

    }
}

using DotNetCore2.Model.Domain.Claim;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Domain.SecurityProfile
{
    public class SecurityProfileDto
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        public IEnumerable<ClaimDto> Claims { get; set; }
    }
}

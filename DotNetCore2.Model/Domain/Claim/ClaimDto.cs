using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Domain.Claim
{
    public class ClaimDto
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public Guid SecurityProfileId { get; set; }
    }
}

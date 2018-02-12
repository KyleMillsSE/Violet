using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore2.Model.Entities.Identity
{
    public class CoreSecurityProfileClaim
    {
        public Guid SecurityProfileId { get; set; }
        public Guid ClaimId { get; set; }

        [ForeignKey("SecurityProfileId")]
        public virtual CoreSecurityProfile SecurityProfile { get; set; }
        [ForeignKey("ClaimId")]
        public virtual CoreClaim Claim { get; set; }
    }
}

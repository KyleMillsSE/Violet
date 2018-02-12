using DotNetCore2.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore2.Model.Entities.Identity
{
    public class CoreSecurityProfile : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CoreSecurityProfileClaim> SecurityProfileClaims { get; set; }
        public virtual ICollection<CoreUser> CoreUsers { get; set; }


        public static class KnownCoreSecurityProfileIds
        {
            public static Guid SuperAdminSecurityProfile = Guid.Parse("a995be22-c5ac-4524-8ebd-fa91a3dd6a25");
            public static Guid AdminSecurityProfile = Guid.Parse("a995be22-c5ac-4524-8ebd-fa91a3dd6a26");
            public static Guid UserSecurityProfile = Guid.Parse("a995be22-c5ac-4524-8ebd-fa91a3dd6a27");
        }
    }
}

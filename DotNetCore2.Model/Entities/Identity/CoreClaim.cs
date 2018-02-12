using DotNetCore2.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore2.Model.Entities.Identity
{
    // TODO: ability to link claims i.e. dependant on another claim to be active before itself can be active
    public class CoreClaim : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CoreSecurityProfileClaim> SecurityProfileClaims { get; set; }

        public static class KnownCoreClaimIds
        {
            //public static Guid ViewUsers = Guid.Parse("e09af3c0-0aab-4dcb-8c3e-c38170f6c6e0");
            public static Guid ViewUser = Guid.Parse("e09af3c0-0aab-4dcb-8c3e-c38170f6c6e1");
            public static Guid EditUser = Guid.Parse("e09af3c0-0aab-4dcb-8c3e-c38170f6c6e2");
            public static Guid DeleteUser = Guid.Parse("e09af3c0-0aab-4dcb-8c3e-c38170f6c6e3");
            public static Guid AddUser = Guid.Parse("e09af3c0-0aab-4dcb-8c3e-c38170f6c6e4");
        }
    }
}

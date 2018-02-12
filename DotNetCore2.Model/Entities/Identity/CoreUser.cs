using DotNetCore2.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore2.Model.Entities.Identity
{

    public class CoreUser : MutableEntity, ISoftEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("SecurityProfile")]
        public Guid SecurityProfileId { get; set; }

        public virtual CoreSecurityProfile SecurityProfile { get; set; }

        public static class KnownCoreUserIds
        {
            public static Guid CoreAdminUser = Guid.Parse("4117bbfa-2c9a-4e75-8da2-8e9855fa789d");
        }
    }
}

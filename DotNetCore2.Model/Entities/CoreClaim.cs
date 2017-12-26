using DotNetCore2.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Entities
{
    public class CoreClaim : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<CoreUserClaim> UserClaims { get; set; }
    }
}

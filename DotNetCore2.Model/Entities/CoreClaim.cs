using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Entities
{
    public class CoreClaim
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<CoreUserClaim> UserClaims { get; set; }
    }
}

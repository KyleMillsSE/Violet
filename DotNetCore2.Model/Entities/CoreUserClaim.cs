using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCore2.Model.Entities
{
    public class CoreUserClaim
    {
        public Guid UserId { get; set; }
        public Guid ClaimId { get; set; }

        [ForeignKey("UserId")]
        public virtual CoreUser User { get; set; }
        [ForeignKey("ClaimId")]
        public virtual CoreClaim Claim { get; set; }
    }
}

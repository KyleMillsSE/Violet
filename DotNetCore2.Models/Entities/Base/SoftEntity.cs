using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCore2.Models.Entities.Base
{
    public class SoftEntity<TId> : BaseEntity<TId>
    {
        [Required, Column(Order = 998)]
        public bool Deleted { get; set; }
    }
}

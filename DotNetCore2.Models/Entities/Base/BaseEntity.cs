using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCore2.Models.Entities.Base
{
    public class BaseEntity<TId>
    {
        [Key, Column(Order = 0)]
        public TId Id { get; set; }


        [ConcurrencyCheck, Required, Timestamp, Column(Order = 999)]
        public byte[] Version { get; set; }

    }
}

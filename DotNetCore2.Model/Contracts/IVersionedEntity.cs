using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCore2.Model.Contracts
{
    public interface IVersionedEntity
    {
        [ConcurrencyCheck, Required, Timestamp]
        byte[] Version { get; set; }
    }
}

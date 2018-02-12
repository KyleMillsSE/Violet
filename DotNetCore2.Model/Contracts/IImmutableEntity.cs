using DotNetCore2.Model.Entities;
using DotNetCore2.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Contracts
{
    public interface IImmutableEntity
    {
        DateTime CreatedAt { get; set; }
        Guid CreatedById { get; set; }
        CoreUser CreatedBy { get; set; }
    }
}

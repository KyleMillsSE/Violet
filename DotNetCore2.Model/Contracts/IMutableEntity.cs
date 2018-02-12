using DotNetCore2.Model.Entities.Identity;
using System;

namespace DotNetCore2.Model.Contracts
{
    public interface IMutableEntity
    {
        DateTime CreatedAt { get; set; }
        Guid CreatedById { get; set; }
        CoreUser CreatedBy { get; set; }
        DateTime ModifiedAt { get; set; }
        Guid ModifiedById { get; set; }
        CoreUser ModifiedBy { get; set; }
    }
}

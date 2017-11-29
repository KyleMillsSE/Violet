using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Contracts
{
    public interface IAuditedEntity
    {
        DateTime Modified { get; set; }
        DateTime ModifiedById { get; set; }

        //add user
    }
}

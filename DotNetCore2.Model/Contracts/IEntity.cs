using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Model.Contracts
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}

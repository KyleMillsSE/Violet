using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.EF.Queries
{
    public interface ICoreGetByIdQuery<T> 
        where T : class
    {
        T Execute(Guid id);
    }
}

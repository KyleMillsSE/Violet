using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.EF.Queries.Contracts
{
    
    public interface ICoreGetAllQuery<T> 
        where T : class
    {
        IEnumerable<T> Execute(bool includeDeleted = false);
    }
}

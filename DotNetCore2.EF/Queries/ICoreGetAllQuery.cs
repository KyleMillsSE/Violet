using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetCore2.EF.Queries
{
    
    public interface ICoreGetAllQuery<T> 
        where T : class
    {
        IQueryable<T> Execute(bool includeDeleted = false);
    }
}

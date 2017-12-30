using DotNetCore2.EF.Queries.Contracts;
using DotNetCore2.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetCore2.EF.Queries
{
    public class CoreGetAllQuery<T> : ICoreGetAllQuery<T> 
        where T : class
    {
        private readonly CoreContext _context;

        public CoreGetAllQuery(CoreContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Execute(bool includeDeleted = false)
        {
            if (typeof(ISoftEntity).IsAssignableFrom(typeof(T)) && !includeDeleted)
                return _context.Set<T>().Where(x => !(x as ISoftEntity).IsDeleted);
            else
                return _context.Set<T>();
        }
    }
}

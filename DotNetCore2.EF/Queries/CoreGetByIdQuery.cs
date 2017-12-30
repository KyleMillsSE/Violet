using System;
using DotNetCore2.EF.Queries.Contracts;

namespace DotNetCore2.EF.Queries
{
    public class CoreGetByIdQuery<T> : ICoreGetByIdQuery<T> 
        where T : class
    {
        private readonly CoreContext _context;

        public CoreGetByIdQuery(CoreContext context)
        {
            _context = context;
        }

        public T Execute(Guid id)
        {
           return _context.Set<T>().Find(id);
        }
    }
}

using DotNetCore2.EF.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace DotNetCore2.EF.Queries.Core
{
    public abstract class GenericQuery<TMdl> : IGenericQuery<TMdl>, IEnumerable<TMdl>  where TMdl : class
    {
        protected readonly DbSet<TMdl> _dbSet;

        public GenericQuery(CoreContext context)
        {
            _dbSet = context.Set<TMdl>();
        }

        public IEnumerator<TMdl> GetEnumerator()
        {
            return ((IEnumerable<TMdl>)_dbSet).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TMdl>)_dbSet).GetEnumerator();
        }
    }
}

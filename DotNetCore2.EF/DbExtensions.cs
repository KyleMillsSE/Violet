using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetCore2.EF
{
    public static class DbExtensions
    {
        /// <summary>
        /// Extension method for removing all entities of particular type from a database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        public static void Clear<T>(this DbContext context) where T : class
        {
            var entities = context.Set<T>();
            entities.RemoveRange(entities.ToList());
            context.SaveChanges();
        }

    }
}

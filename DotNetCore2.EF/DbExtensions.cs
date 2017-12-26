using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DotNetCore2.EF
{
    public static class DbExtensions
    {
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T entity) where T : class
        {
            var t = typeof(T);
            PropertyInfo keyField = null;
            foreach (var propt in t.GetProperties())
            {
                var keyAttr = propt.GetCustomAttribute<KeyAttribute>();
                if (keyAttr != null)
                {
                    keyField = propt;
                    break; // assume no composite keys
                }
            }
            if (keyField == null)
            {
                throw new Exception($"{t.FullName} does not have a KeyAttribute field. Unable to exec AddOrUpdate call.");
            }
            var keyVal = keyField.GetValue(entity);
            var dbVal = dbSet.Find(keyVal);
            if (dbVal != null)
            {
                dbSet.Update(entity);
                return;
            }
            dbSet.Add(entity);
        }

        public static void AddOrUpdate<T>(this DbSet<T> dbSet, IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                dbSet.AddOrUpdate(entity);
            }
        }
    }
}

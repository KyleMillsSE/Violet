using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore2.Model
{
    public static class Extensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null) return null;
  
            foreach (var element in sequence)
                action(element);

            return sequence;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();

            return source.Where(element => seenKeys.Add(keySelector(element)));
        }

        public static TDestination MapTo<TDestination>(this object source) where TDestination : class
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap(source.GetType(), typeof(TDestination)));
            return (TDestination)config.CreateMapper().Map(source, source.GetType(), typeof(TDestination));
        }


        /// <summary>
        /// Maps values of properties from object to another if type and property name are the same
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="inputObj"></param>
        /// <returns></returns>
        public static TOut Mapper<TIn, TOut>(TIn inputObj)
        {
            dynamic outputObj = Activator.CreateInstance(typeof(TOut));

            foreach (var inputObjProp in inputObj.GetType().GetProperties())
            {
                var retValProperty = outputObj.GetType().GetProperty(inputObjProp.Name);
                if (retValProperty != null && retValProperty.PropertyType == inputObjProp.PropertyType)
                {
                    var inputPropertyValue = inputObjProp.GetValue(inputObj, null);
                    retValProperty.SetValue(outputObj, inputPropertyValue, null);
                }
            }
            return outputObj;
        }
    }
}

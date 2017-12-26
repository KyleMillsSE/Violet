using System;
using System.Collections.Generic;

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
    }
}

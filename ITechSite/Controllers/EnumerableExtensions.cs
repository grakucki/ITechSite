using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITechSite
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(
            this  IEnumerable<T> source, params T[] tail)
        {
            return source.Concat(tail);
        }
    }
}
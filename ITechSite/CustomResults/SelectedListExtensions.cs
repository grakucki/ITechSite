using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite
{
    public static class IListExtensions
    {
       
        public static IList<SelectListItem> ToSelectedList<TSource>(this IList<TSource> source, Func<TSource, SelectListItem> selector)
        {
            if (source == null)
                return null;


            return source.Select(m => selector(m)).ToList();
        }
    }
}

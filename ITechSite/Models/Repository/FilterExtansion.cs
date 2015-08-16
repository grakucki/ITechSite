using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITechSite.Models.Repository
{
    public class FilterExtansion
    {
        
        /// <summary>
        ///   sprawdza czy filtr jest pusty tz null, empty lub '*'
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static bool IsEmpty(string filter)
        {
               if (string.IsNullOrEmpty(filter))
                    return true;
                if (filter=="*")
                    return true;
                return false;
        }

        /// <summary>
        ///   sprawdza czy filtr jest pusty tz null, empty lub równy parametrowiempty
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static bool IsEmpty(string filter, string empty)
        {
            if (string.IsNullOrEmpty(filter))
                return true;
            if (filter == empty)
                return true;
            return false;
        }

        /// <summary>
        ///   sprawdza czy filtr jest pusty tz null, empty lub <=0
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static bool IsEmpty(int? filter)
        {
            if (!filter.HasValue)
                return true;
            if (filter.Value <= 0)
                return true;
            return false;
        }


        /// <summary>
        ///   sprawdza czy filtr jest pusty tz null, empty lub <= parametrowi empty
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static bool IsEmpty(int? filter, int empty)
        {
            if (!filter.HasValue)
                return true;
            if (filter.Value <= empty)
                return true;
            return false;
        }

    }
}
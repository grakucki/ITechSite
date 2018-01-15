using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ITechSite.Models
{
    public partial class ITechEntities : DbContext
    {
        private static string ReplaceCaseInsensitive(string input, string search, string replacement)
        {
            string result = Regex.Replace(
                input,
                Regex.Escape(search),
                replacement.Replace("$", "$$"),
                RegexOptions.IgnoreCase
            );
            return result;
        }
        public static string GetPrepareConnectionString(string name)
        {
            var c = ConfigurationManager.ConnectionStrings[name];
            var comp = Environment.MachineName;
            string ret = string.Empty;
            
                ret =name;
            return ret;
        }

        public static string EntitiesName()
        {

            int i = 1;
            var comp = Environment.MachineName;
           
            String n=string.Empty;
            switch (i)
            {
                case 0: n = "name=ITechEntities";
                    break;
                case 1: n = "name=ITechEntities2";
                    break;
                
                default:
                    n = "name=ITechEntities";
                    break;
            }
            return n;
        }

        //base("DefaultConnection", throwIfV1Schema: false)
        public ITechEntities(int i)
            : base(EntitiesName())
        {

        }

        public ITechEntities(string s)
            : base(s)
        {

        }
    }

    public class ITechEntities2 : ITechEntities
    {
        public ITechEntities2()
            : base(ITechEntities.EntitiesName())
        {

        }
    }


}
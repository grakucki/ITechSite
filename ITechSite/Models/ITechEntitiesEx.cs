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
            if (comp.ToLower() == "akacjowa5")
            {
                if (c != null)
                {
                    ret = ReplaceCaseInsensitive(c.ConnectionString,@"data source=COOLER7\SQLEXPRESS", @"data source=Akacjowa5\");
                }
            }
            else
                ret =name;
            return ret;
        }

        public static string EntitiesName()
        {

            int i = 1;
            var comp = Environment.MachineName;
            if (comp == "AKACJOWA5")
                i = 2;
            String n=string.Empty;
            switch (i)
            {
                case 0: n = "name=ITechEntities";
                    break;
                case 1: n = "name=ITechEntities2";
                    break;
                case 2:
                    {
                        var c = ConfigurationManager.ConnectionStrings["ITechEntities2"];
                        n = c.ConnectionString.Replace(@"data source=COOLER7\SQLEXPRESS",@"data source=Akacjowa5\" );
                        //n = "name=ITechEntities2";
                        //n = @"metadata=res://*/Models.ITechModel.csdl|res://*/Models.ITechModel.ssdl|res://*/Models.ITechModel.msl;provider=System.Data.SqlClient;provider connection string='data source=Akacjowa5\;initial catalog=ITech;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework'";
                    }
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
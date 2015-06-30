using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    public partial class ITechEntities : DbContext
    {
        private static string EntitiesName()
        {

            int i = 1;
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
    }


    [MetadataType(typeof(ResourceMetaData))]
    public partial class Resource
    {

    }


    public class ResourceMetaData
    {
        [Unique]
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        public string Name { get; set; }
    }
}
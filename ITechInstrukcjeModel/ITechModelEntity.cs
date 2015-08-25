using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using System.Runtime.Serialization;

using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;


namespace ITechInstrukcjeModel
{

    public class Simatic
    {
        public static string[] AvalibleSimaticCpuType = new string[] {
        "S7200" ,
        "S7300" ,
        "S7400" ,
        "S71200",
        "S71500",
        "Demo",
        "Brak"};
        
    }



    public partial class News
    {
        public static News Clone(News o)
        {
            return new News().From(o);
        }
    }

     public partial class ItechUsers
     {
         /// czy należy to tej jednej konkretnej roli
         public bool IsInRole(string rolename)
         {
             return this.AspNetRoles.Any(m => m.Name == rolename);
         }

         /// czy należy jednej z podanych ról
         public bool IsInRoles(string[] rolenames)
         {
             foreach (var rolename in rolenames)
             {
                 if (this.AspNetRoles.Any(m => m.Name == rolename)==true)
                    return true;
             }

             return false;
         }

         /// czy należy jednej z podanych ról
         /// role należy podawać po przecinku
         public bool IsInRoles(string rolenames)
         {
             char[] stringSeparators = new char[] { ',' };
             var r = rolenames.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
             return IsInRoles(r);
         }

     }


     public partial class ModelsWorkstation
     {
         public string ModelName
         {
             get
             {
                 var x = this.Models.Name;
                 return x ;
             }
         }
     }

     //public partial class AspNetRoles
     //    [System.Runtime.Serialization.IgnoreDataMember]
     //    public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }


    //public partial class Dokument
    //{
     //   [System.Runtime.Serialization.IgnoreDataMember]
    //    public ICollection<InformationPlan> InformationPlan { get; set; }
    //}

    //public partial class InformationPlan
    //{
     //   [System.Runtime.Serialization.IgnoreDataMember]
    //    //public virtual Resource Resource { get; set; }
    //}

     //public partial class Kategorie
     //{
     //    [System.Runtime.Serialization.IgnoreDataMember]
     //    public virtual ICollection<Dokument> Dokument { get; set; }
     //}

     //public partial class ModelsWorkstation
     //[System.Runtime.Serialization.IgnoreDataMember]
     //public virtual Resource Workstation { get; set; }
     //[System.Runtime.Serialization.IgnoreDataMember]
     //public virtual Resource Models { get; set; }


    //public partial class News
    //{
     //    [System.Runtime.Serialization.IgnoreDataMember]
    //    public virtual Resource Resource { get; set; }
    //}

    //public partial class Workstation
    //{
     //    [System.Runtime.Serialization.IgnoreDataMember]
    //    public virtual Resource Resource { get; set; }
    //}
}

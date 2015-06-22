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
        public static string[] AvalibleSimaticCpuType = new string[] {"S7200" ,
        "S7300" ,
        "S7400" ,
        "S71200",
        "S71500"};
    }

    [MetadataType(typeof(DokumentMetaData))]
    public partial class Dokument
    {

    }


    public class DokumentMetaData
    {
        [IgnoreDataMember]
        public ICollection<InformationPlan> InformationPlan { get; set; }

    }



    //public partial class Dokument
    //{
    //    [IgnoreDataMember]
    //    public ICollection<InformationPlan> InformationPlan { get; set; }
    //}


    [MetadataType(typeof(InformationMetaData))]
    public partial class InformationPlan
    {

    }


    public class InformationMetaData
    {
        [IgnoreDataMember]
        public Resource Resource { get; set; }
    }


    //public partial class InformationPlan
    //{
    //    //[IgnoreDataMember]
    //    //public virtual Resource Resource { get; set; }
    //}
}

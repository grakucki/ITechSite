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


namespace ITechInstrukcjeModel
{
    public partial class Dokument
    {
        //[IgnoreDataMember]
        //public virtual ICollection<InformationPlan> InformationPlan { get; set; }
    }

    public partial class InformationPlan
    {
        //[IgnoreDataMember]
        //public virtual Resource Resource { get; set; }
    }
}

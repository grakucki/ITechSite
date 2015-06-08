using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
     //[CollectionDataContract(Name = "PlanInformacyjny", Namespace = "http://PlanInforamcyjny")]
     [DataContract(Name = "PlanInforamcyjny", Namespace = "http://PlanInforamcyjny")]
    class PlanInformacyjny
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Nazwa { get; set; }
        [DataMember]
        public string Resource { get; set; }


         [DataMember]
        public string UserName { get; set; }


         [DataMember]
        public List<PlanInformacyjnyItem> Pliki { get; set; }
    }

     [DataContract(Name = "PlikiPlanuInformacyjnego", Namespace = "http://PlanInforamcyjny")]
     class PlanInformacyjnyItem
    {
        [DataMember]
        public string Nazwa { get; set; }
        [DataMember]
        public string Plik { get; set; }
        [DataMember]
        public int Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ItechGeneratorInstrukcji
{
    public class ModelResolver : DataContractResolver
    {
        public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            if (dataContractType.BaseType == typeof(Resource))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("Resource");
                typeNamespace = dictionary.Add("http://schemas.datacontract.org/2004/07/ItechGeneratorInstrukcji");
                return true; // indicating that this resolver knows how to handle "Dog".
            }
            else if (dataContractType.BaseType == typeof(InformationPlan))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("InformationPlan");
                typeNamespace = dictionary.Add("http://schemas.datacontract.org/2004/07/ItechGeneratorInstrukcji");
                return true;
            }
            else if (dataContractType.BaseType == typeof(Dokument))
            {
                XmlDictionary dictionary = new XmlDictionary();
                typeName = dictionary.Add("Dokument");
                typeNamespace = dictionary.Add("http://schemas.datacontract.org/2004/07/ItechGeneratorInstrukcji");
                return true;
            }
            else
            {
                // Defer to the known type resolver
                return knownTypeResolver.TryResolveType(dataContractType, declaredType, null, out typeName, out typeNamespace);
            }
        }


        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            if (typeName.IndexOf("Dokument") >= 0)
            {
                return typeof(Dokument);
            }
            else if (typeName.IndexOf("Resource") >= 0)
            {
                return typeof(Resource);
            }
            else if (typeName.IndexOf("InformationPlan") >= 0)
            {
                return typeof(InformationPlan);
            }
            else
            {
                // Defer to the known type resolver
                return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null);
            }
        }
    }
}

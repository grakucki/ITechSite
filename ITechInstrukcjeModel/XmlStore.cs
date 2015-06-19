using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ITechInstrukcjeModel
{
    public class XmlStore
    {
        /// <summary>
        /// use [DataContract] and [DataMember] in class to save
        /// </summary>
        /// <param name="objectToSerialize">obiekkt do serializacji</param>
        /// <param name="filename"> pełna nazwa pliku </param>
        public static void SaveToXml(string filename, object objectToSerialize, DataContractResolver dataContractResolver = null)
        {

            using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create(filename)))
            {
                //System.Runtime.Serialization.
                DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType());
                serializer.WriteObject(writer, objectToSerialize);
            }
        }


        public static object LoadFromXmlOrDefault(string filename, Type type, DataContractResolver dataContractResolver = null)
        {
            try
            {
                if (File.Exists(filename))
                {
                    return LoadFromXml(filename, type, dataContractResolver);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Activator.CreateInstance(type);
        }

        public static T LoadFromXmlOrDefault<T>(string filename, DataContractResolver dataContractResolver = null)
        {
            try
            {
                if (File.Exists(filename))
                {
                    return (T)LoadFromXml(filename, typeof(T), dataContractResolver);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return (T) Activator.CreateInstance<T>();
        }


        public static object LoadFromXml(string filename, Type type, DataContractResolver dataContractResolver = null)
        {

            DataContractSerializer dcs = new DataContractSerializer(type, null, Int32.MaxValue, false, false, null, dataContractResolver);
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            Object o = dcs.ReadObject(reader);
            reader.Close();
            fs.Close();


            return o;
        }
    }
}

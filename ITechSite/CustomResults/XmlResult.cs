using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ITechSite
{
    public class XmlResult : ActionResult
    {
        private object objectToSerialize;

        /// <Summary> 
        /// Inicjuje nowe wystąpienie <zobacz cref = "XmlResult" /> klasy. 
        /// </ summary> 
        /// <param name = "objectToSerialize"> obiektu do serializacji XML . </ param> 
        public XmlResult(object objectToSerialize)
        {
            this.objectToSerialize = objectToSerialize;
        }

        /// <Summary> 
        /// Pobiera obiekt do szeregowane do XML. 
        /// </ summary> 
        public object ObjectToSerialize
        {
            get { return this.objectToSerialize; }
        }

        /// <Summary> 
        /// Serialises obiekt, który został przekazany do konstruktora do XML i zapisuje odpowiednie XML do strumienia wynikowego. 
        /// </ summary> 
        /// <param name = "Kontekst"> Sterownik kontekst dla prądu request.</param> 
        public override void ExecuteResult(ControllerContext context)
        {
            if (this.objectToSerialize != null)
            {

                context.HttpContext.Response.Clear();
                //var xs = new System.Xml.Serialization.XmlSerializer(this.objectToSerialize.GetType());
                context.HttpContext.Response.ContentType = "text/xml";
                //xs.Serialize(context.HttpContext.Response.Output, this.objectToSerialize);

                using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
                {
                    //System.Runtime.Serialization.
                    DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType());
                    serializer.WriteObject(writer, objectToSerialize);
                }


            }
        }
    }
}
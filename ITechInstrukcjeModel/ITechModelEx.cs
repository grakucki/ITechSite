﻿using System;
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
using System.Diagnostics;


namespace ITechInstrukcjeModel
{
    public partial class ITechEntities
    {

        public string WorkDir { get; set; }
        public List<Resource> ResourceList { get; set; }

        public List<Resource> ResourceModel
        {
            get
            {
                return this.Resource.Local.Where(m => m.Type == 2).ToList();
            }

        }


        public List<Resource> ResourceWorkstation
        {
            get
            {
                return this.Resource.Local.Where(m => m.Type == 1).ToList();
            }

        }

        /// <summary>
        /// use [DataContract] and [DataMember] in class to save
        /// </summary>
        /// <param name="objectToSerialize">obiekkt do serializacji</param>
        /// <param name="filename"> pełna nazwa pliku </param>
        private void SaveToXml(object objectToSerialize, string filename)
        {

            using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create(filename)))
            {
                //System.Runtime.Serialization.
                DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType(), null, Int32.MaxValue, false, false, null, new ModelResolver());
                serializer.WriteObject(writer, objectToSerialize);
            }
        }

       
        public List<Resource> LoadFromXml(string filename)
        {

            DataContractSerializer dcs = new DataContractSerializer(typeof(List<Resource>), null, Int32.MaxValue, false, false, null, new ModelResolver());
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            List<Resource> plan = (List<Resource>)dcs.ReadObject(reader);
            reader.Close();
            fs.Close();


            return plan;
        }
        /// <summary>
        /// Load resource from xml file 
        /// </summary>
        /// <returns></returns>
        public List<Resource> ImportResource()
        {
            var resourcesFile = Path.Combine(WorkDir, "resources.xml");
           
            ResourceList = LoadFromXml(resourcesFile);
            this.Resource.Local.Clear();
            this.Resource.AddRange(ResourceList);
            return ResourceList;
        }


        public string GetFileDocName(int DocId)
        {
            var d = this.Dokument.Local.Where(m => m.Id == DocId).FirstOrDefault();
            if (d == null)
                return "Nie odnaleziono dokumentu";

            return CreateLocalFileName(d);
        }

        public void ExportResources()
        {
            
            if (!Directory.Exists(WorkDir))
                Directory.CreateDirectory(WorkDir);
            using (var db = new ITechEntities())
            {
                var q = db.Resource.Where(m => m.Enabled).OrderBy(m => m.Id).ToList();
                SaveToXml(q, Path.Combine(WorkDir, "resources.xml"));
            }
        }

        public void ExportDokuments()
        {
            var DokDir = Path.Combine(WorkDir, "Dokuments");
            if (!Directory.Exists(DokDir))
                Directory.CreateDirectory(DokDir);
            // pobieramy listę dokumentów
            using (var db = new ITechEntities())
            {
                var doks = db.Dokument.Where(m => m.Enabled).ToList();
                foreach (var item in doks)
                {
                    ExportDok(db, DokDir, item);
                }
            }
        }

        public String CreateLocalFileName(Dokument item)
        {
            var DokDir = Path.Combine(WorkDir, "Dokuments");
            return Path.Combine(DokDir, "Dok_" + item.Id + item.FileType);
        }

        //public void ExportDok(ITechEntities db, string DestPath, Dokument item)
        public void ExportDok(ITechEntities db, string DestPath, Dokument item)
        {
            var cmd = "SELECT Content.PathName() AS FilePath, GET_FILESTREAM_TRANSACTION_CONTEXT() AS 'Context', DATALENGTH(Content) AS 'Size'  FROM FileContent WHERE Dokument_Id= @ItemID";

            using (var trans = db.Database.BeginTransaction())
            {
                var rowData = db.Database.SqlQuery<FileStreamRowData>(cmd, new SqlParameter("ItemID", item.Id)).FirstOrDefault();

                if (rowData != null)
                {
                    using (var source = new SqlFileStream(rowData.FilePath, rowData.Context, FileAccess.Read))
                    {
                        var filename = CreateLocalFileName(item);
                        using (FileStream local = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            source.CopyTo(local);
                        }
                    }
                }
            }
        }

    }
}

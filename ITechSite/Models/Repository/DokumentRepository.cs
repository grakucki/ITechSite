using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using ITechSite.Models;
using System.Data.Entity.Validation;
using System.IO;
using PagedList;

namespace ITechSite.Models.Repository
{
    public class DokumentRepository
    {
        private ITechEntities _dataContex;

        public DokumentRepository()
        {
            _dataContex = new ITechEntities(0);
        }

        public DokumentRepository(ITechEntities dataContex)
        {
            _dataContex = dataContex;
        }

        public int? CreateDoc(Dokument dokument)
        {
            if (_dataContex == null)
                return null;

            dokument.LastWriteTime = DateTime.Now;
            dokument.FileType = Path.GetExtension(dokument.FileName);
            if (dokument.File != null)
            {
                long i = dokument.File.Length;
                var fc = new FileContent();
                fc.CodeName = dokument.CodeName;
                byte[] c = { 0 };
                fc.Content = c;
                fc.FileID = Guid.NewGuid();
                dokument.FileContent.Add(fc);

                _dataContex.Dokument.Add(dokument.GetDokument());
                _dataContex.SaveChanges();

                // zapisz plik
                FileData uploadData = new FileData();
                uploadData.Name = dokument.CodeName;
                uploadData.File = dokument.File;
                var fileRepository = new DBFile();
                fileRepository.Save(uploadData, fc.FileID);
                return dokument.Id;
            }
            return null;
        }

        public List<Kategorie> GetKategorie(bool AddEmpty = true)
        {
            var kat = new List<Kategorie>();
            if (AddEmpty)
                kat.Add(new Kategorie { id = -1, name = "*" });
            kat.AddRange(_dataContex.Kategorie.OrderBy(m => m.name));
            return kat;
        }

        public List<Dokument> GetDokuments(int? kategoriaId, int? WorkProcess, string filter)
        {
            var query = _dataContex.Dokument.AsQueryable();
            if (!Models.Repository.FilterExtansion.IsEmpty(kategoriaId))
                    query = query.Where(m => m.Kategoria_Id == kategoriaId);

            if (!Models.Repository.FilterExtansion.IsEmpty(WorkProcess))
                query = query.Where(m => m.WorkProcess_Id == WorkProcess);

            if (!Models.Repository.FilterExtansion.IsEmpty(filter))
                query = query.Where(m => (m.CodeName.Contains(filter) || m.FileName.Contains(filter) || m.Description.Contains(filter) || m.Keywords.Contains(filter)));

            query = query.Include(d => d.WorkProcess).Include(d => d.Kategorie);
            return query.ToList();
        }

        public List<WorkProcess> GetWorkProcessAll(bool AddEmpty = true)
        {
            var query = _dataContex.WorkProcess;
            var l = query.ToList<WorkProcess>();
            if (AddEmpty)
                l.Insert(0, new WorkProcess { Name = "*", Id = 0 });
            return l;
        }

        public IList<InformationPlan> IncludeInformationPlainDoc(int? idW, int? idM)
        {
            var query = _dataContex.InformationPlan.AsQueryable();
            if (idM.HasValue && idM!=0)
                query = query.Where(m => m.idR == idW && m.IdM==idM);
            else
                query = query.Where(m => m.idR == idW);
            return query.OrderBy(m=>m.Dokument.FileName).ToList();
        }


        public IList<Dokument> GetAvalibleDoc(int IdR, int? IdM, string WorkProcess, string filter, int? kategoriaId)
        {
            
            var query = _dataContex.Dokument.AsQueryable();
  

            query = query.Where(m => m.Enabled == true);

            if (!Models.Repository.FilterExtansion.IsEmpty(kategoriaId))
                query = query.Where(m => m.Kategoria_Id == kategoriaId);

            if (!Models.Repository.FilterExtansion.IsEmpty(WorkProcess))
            {
                var x = _dataContex.WorkProcess.Where(m => m.Name == WorkProcess).FirstOrDefault();
                if (x!=null)
                    query = query.Where(m => m.WorkProcess_Id == x.Id);
            }

            if (!Models.Repository.FilterExtansion.IsEmpty(filter))
                query = query.Where(m => (m.CodeName.Contains(filter) || m.FileName.Contains(filter) || m.Description.Contains(filter) || m.Keywords.Contains(filter)));

            query = query.Where(m => !m.InformationPlan.Any(n => n.idR == IdR && n.IdM == IdM));
            query = query.Include(d => d.WorkProcess).Include(d => d.Kategorie);

            return query.OrderBy(m=>m.FileName).ToList();
        }
    }
}
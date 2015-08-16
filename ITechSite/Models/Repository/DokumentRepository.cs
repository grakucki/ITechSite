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

    }
}
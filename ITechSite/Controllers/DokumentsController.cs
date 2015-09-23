using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITechSite.Models;
using System.Data.Entity.Validation;
using System.IO;
using PagedList;

namespace ITechSite.Controllers
{
    [Authorize]
    public class DokumentsController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

        // GET: Dokuments
       // public ActionResult Index()
       // {
       //     //var dokument = db.Dokument.Include(d => d.FileContent).Include(d => d.WorkProcess);
       //     var dokument = db.Dokument.Include(d => d.WorkProcess);
       //     return View(dokument.ToList());
       //}


        //public ActionResult Index(string CodeName)
        //{
        //    //FindDokumentModel Find = Find1.Find;
        //    //var dokument = db.Dokument.Include(d => d.FileContent).Include(d => d.WorkProcess);
        //    IndexDokumentModel model = new IndexDokumentModel();
        //    model.CodeName = CodeName;

        //    if (CodeName==null)
        //        model.CodeName= (string) Session["DokumentCodeName"];
        //    else
        //        Session["DokumentCodeName"]=model.CodeName;
        //    if (!string.IsNullOrEmpty(model.CodeName))
        //        model.Dokuments = db.Dokument.Where(m => m.CodeName.IndexOf(model.CodeName) >= 0).Include(d => d.WorkProcess);
        //    else
        //        model.Dokuments = db.Dokument.Include(d => d.WorkProcess);
        //    return View(model);
        //}
        public ActionResult Find(IndexDokumentModel model)
        {
            return RedirectToAction("index");
        }

        public ActionResult Index(IndexDokumentModel model)
        {
            if (model == null)
                model = new IndexDokumentModel();


            if (string.IsNullOrEmpty(model.FindAction))
            {
                if (Session["DokumentCodeName"] != null)
                    model = (IndexDokumentModel)Session["DokumentCodeName"];
            }
            else
                Session["DokumentCodeName"] = model;



            var repo = new ITechSite.Models.Repository.DokumentRepository();
            var query = repo.GetDokuments(model.Kategorie_Id, model.WorkProcess, model.CodeName);
            model.Dokuments = query.OrderBy(m => m.CodeName).ToPagedList(model.page ?? 1, 10);
            ViewBag.Kategoria_Id = new SelectList(repo.GetKategorie(), "id", "name");
            ViewBag.WorkProcess = new SelectList(repo.GetWorkProcessAll(), "id", "name");


            return View(model);
        }
        // GET: Dokuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokument.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // GET: Dokuments/Create
        public ActionResult Create()
        {
            ViewBag.FileContent_Id = new SelectList(db.FileContent, "Id", "FileName");
            ViewBag.WorkProcess_Id = new SelectList(db.WorkProcess, "Id", "Name");
            ViewBag.Kategoria_Id = new SelectList(db.Kategorie, "Id", "name");
            var model = new Dokument();
            model.CodeName = "D001";
            model.ValidDtmOn = DateTime.Now;
            model.Description = "";
            model.Enabled = true;
            return View(model);
        }

        // POST: Dokuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,CodeName,Enabled,Description,ValidDtmOn,ValidDtmOff,WorkProcess_Id,File,Kategoria_Id, Keywords")] Dokument dokument)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dokument.LastWriteTime = DateTime.Now;
                    dokument.FileType = Path.GetExtension(dokument.FileName);
                    if (dokument.File != null)
                    {
                        long i = dokument.File.Length;
                        var fc = new FileContent();
                        fc.CodeName = dokument.CodeName;
                        byte [] c = {0};
                        fc.Content = c;
                        fc.FileID = Guid.NewGuid();
                        dokument.FileContent.Add(fc);

                        db.Dokument.Add(dokument.GetDokument());
                        db.SaveChanges();

                        // zapisz plik
                        FileData uploadData = new FileData();
                        uploadData.Name = dokument.CodeName;
                        uploadData.File = dokument.File;
                        var fileRepository = new DBFile();
                        fileRepository.Save(uploadData, fc.FileID);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("File", string.Format("Podaj plik."));
                    }
                }

                ViewBag.WorkProcess_Id = new SelectList(db.WorkProcess, "Id", "Name", dokument.WorkProcess_Id);
                ViewBag.Kategoria_Id = new SelectList(db.Kategorie, "Id", "name", dokument.Kategoria_Id);
            }
            catch (DbEntityValidationException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }
          
            return View(dokument);
        }

    
        // GET: Dokuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokument.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            //ViewBag.WorkProcess_Id = new SelectList(db.WorkProcess, "Id", "Name", dokument.WorkProcess_Id);
            //ViewBag.Kategoria_Id = new SelectList(db.Kategorie, "Id", "name", dokument.Kategoria_Id);
            var repo = new ITechSite.Models.Repository.DokumentRepository();

            ViewBag.WorkProcess_Id = new SelectList(repo.GetWorkProcessAll(true), "Id", "Name", dokument.WorkProcess_Id);
            ViewBag.Kategoria_Id = new SelectList(repo.GetKategorie(true), "Id", "name", dokument.Kategoria_Id);


            return View(dokument);
        }

        private void SaveFileContent(Dokument dokument)
        {
            if (dokument.File != null)
            {
                //var fileID = db.Dokument.Where(m => m.Id == dokument.Id).FirstOrDefault().FileContent.Select(b => b.FileID).FirstOrDefault();
                var x = db.Entry(dokument).Collection(f=>f.FileContent).Query().Select(f => f.FileID);
                var fileID = x.FirstOrDefault();
                if (fileID == null)
                {
                    // rekort FileContent nie isnieje
                    var fc = new FileContent();
                    fc.CodeName = dokument.CodeName;
                    byte[] c = { 0 };
                    fc.Content = c;
                    fc.FileID = Guid.NewGuid();
                    fileID = fc.FileID;
                    dokument.FileContent.Add(fc);
                    db.SaveChanges();
                }
                // zapisujemy plik
                // zapisz plik

                if (dokument.File.Length>0)
                { 
                    // zapisujemy dane pliku tylko gdy został podany
                    FileData uploadData = new FileData();
                    uploadData.Name = dokument.CodeName;
                    uploadData.File = dokument.File;

                    var fileRepository = new DBFile();
                    fileRepository.Save(uploadData, fileID);
                }
            }
        } 

        // POST: Dokuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,CodeName,Enabled,Description,ValidDtmOn,ValidDtmOff,WorkProcess_Id,File,Kategoria_Id,Keywords")] Dokument dokument)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    dokument.LastWriteTime = DateTime.Now;
                    dokument.FileType = Path.GetExtension(dokument.FileName);
                    db.Entry(dokument).State = EntityState.Modified;

                    db.SaveChanges();

                    SaveFileContent(dokument);

                    return RedirectToAction("Index");
                }
                //ViewBag.WorkProcess_Id = new SelectList(db.WorkProcess, "Id", "Name", dokument.WorkProcess_Id);
                //ViewBag.Kategoria_Id = new SelectList(db.Kategorie, "Id", "name", dokument.Kategoria_Id);

                var repo = new ITechSite.Models.Repository.DokumentRepository();
                ViewBag.WorkProcess_Id = new SelectList(repo.GetWorkProcessAll(true), "Id", "Name", dokument.WorkProcess_Id);
                ViewBag.Kategoria_Id = new SelectList(repo.GetKategorie(true), "Id", "name", dokument.Kategoria_Id);

            }
            catch (DbEntityValidationException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            return View(dokument);
        }

        // GET: Dokuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokument.Find(id);
            if (dokument.InformationPlan.Count() > 0)
                ViewBag.DontDelete = "Nie można usunąć tego dokumentu. Jest on używany w prezentacjach. Usuń dokument z prezentacji i spróbuj ponownie";

            if (dokument == null)
            {
                return HttpNotFound();
            }

            return View(dokument);
        }

        // POST: Dokuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dokument dokument = db.Dokument.Find(id);
            var doks = dokument.FileContent.ToList();
            foreach (var item in doks)
            {
                db.FileContent.Remove(item);
            }
            db.Dokument.Remove(dokument);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Download(int id)
        {
            Dokument dokument = db.Dokument.Find(id);
            if (dokument==null)
                throw new HttpException(404, "Not found");
            var query = (from x in dokument.FileContent select x.FileID).FirstOrDefault();
            
            return new SqlFileStreamResult(new DBFile().Get(query), dokument.FileName, "application/octet-stream");
        }


        [HttpGet]
        public FileResult Show(int id)
        {
            Dokument dokument = db.Dokument.Find(id);
            if (dokument == null)
                throw new HttpException(404, "Not found");
            var query = (from x in dokument.FileContent select x.FileID).FirstOrDefault();

            return new SqlFileStreamResult(new DBFile().Get(query), "", MimeMapping.GetMimeMapping(dokument.FileName));
        }

        [HttpGet]
        public ActionResult Join(int idd)
        {
            JoinDoc doc = new JoinDoc();

            doc.Doc = db.Dokument.Find(idd);
            var rlf = new ResourceListFind();
            rlf.Allow_ResourceType = false;
            ViewBag.FindResources = rlf.Fill(db);

            doc.AvalibleWorkstation = rlf.GetWorkstation(db);
            doc.AvalibleModels = db.Resource.Where(m => m.Type == 2).ToList();

            return View(doc);
        }

        [HttpPost]
        public ActionResult Join(int idd, ResourceListFind rf)
        {
            JoinDoc doc = new JoinDoc();

            doc.Doc = db.Dokument.Find(idd);
            var rlf = ResourceListFind.From(rf);
           
            rlf.Allow_ResourceType = false;
            ViewBag.FindResources = rlf.Fill(db);

            doc.AvalibleWorkstation = rlf.GetWorkstation(db);
            doc.AvalibleModels = db.Resource.Where(m => m.Type == 2).ToList();

            return View(doc);
        }

    }
}

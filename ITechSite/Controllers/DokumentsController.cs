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
                    dokument.CreateTime = DateTime.Now;
                    dokument.OwnerId =User.Identity.Name;

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

                        return RedirectToAction("Details", new { id = dokument.Id});
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
            JoinDoc joinDoc = new JoinDoc();

            joinDoc.Doc = db.Dokument.Find(idd);
            var rlf = new ResourceListFind();
            rlf.Allow_ResourceType = false;
            ViewBag.FindResources = rlf.Fill(db);

            joinDoc.WorkstationList = rlf.GetWorkstations(db);
            // w get nie wyświelamy listy modeli

            var ModelsList = rlf.GetModelsByWorkstations(db, null, null).ToList();
            joinDoc.AvalibleModels = ModelsList.ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });

            if (joinDoc.ModelId != null)
                joinDoc.ModelsList = ModelsList.Where(m => m.Id == joinDoc.ModelId).OrderBy(m => m.Name).ToList();

            return View(joinDoc);
        }

        public bool JoinCheckValues(int? ModelId, int[] WorkstationsCheck, int[] ModelsCheck)
        {
            if (WorkstationsCheck==null)
                ModelState.AddModelError("", "Zaznacz stanowiska");

            if (ModelId.HasValue)
                if (ModelsCheck == null)
                    ModelState.AddModelError("", "Zaznacz modele lub warianty");

            if (!ModelId.HasValue && ModelsCheck!=null)
                ModelState.AddModelError("", "Zdecuduj się czy jest to dokument stanowiskowy czy modelowy?");


            var allErrors = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault();
            if (allErrors == null)
                return true;
            return false;
        }

        public ActionResult offjoin(int id)
        {
            var d = db.InformationPlan.Find(id);
            if (d==null)
                return RedirectToAction("Index");

            db.InformationPlan.Remove(d);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = d.IdD });
        }

        [HttpPost]
        public ActionResult Join(int idd, int? ModelId, int[] WorkstationsCheck, int[] ModelsCheck, ResourceListFind rf)
        {
             
            if (rf!=null)
            {
                if (rf.FindAction == "Cancel")
                {
                    return RedirectToAction("Details", new { id = idd });
                }
                if (rf.FindAction=="AddDoc")
                {
                    if (JoinCheckValues(ModelId, WorkstationsCheck, ModelsCheck))
                    {
                        if (JoinDocAction(idd, WorkstationsCheck, ModelsCheck))
                            return RedirectToAction("Details", new { id = idd });
                    }
                }
            }

            JoinDoc joinDoc = new JoinDoc();
            joinDoc.Doc = db.Dokument.Find(idd);
            joinDoc.ModelId = ModelId;
            joinDoc.WorkstationsCheck = WorkstationsCheck;
            joinDoc.ModelsCheck = ModelsCheck;
            var rlf = ResourceListFind.From(rf);
           
            rlf.Allow_ResourceType = false;
            ViewBag.FindResources = rlf.Fill(db);

            joinDoc.WorkstationList = rlf.GetWorkstations(db);

            var ModelsList = rlf.GetModelsByWorkstations(db, null, null).ToList();
            joinDoc.AvalibleModels = ModelsList.ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });

            if (joinDoc.ModelId!=null)
                joinDoc.ModelsList = ModelsList.Where(m => m.Id == joinDoc.ModelId).OrderBy(m => m.Name).ToList();


            return View(joinDoc);
        }


        private bool JoinDocAction(int idd, int[] WorkstationsCheck, int[] ModelsCheck)
        {
            bool ret = true;
            try
            {
                foreach (var idw in WorkstationsCheck)
                {
                    if (ModelsCheck != null)
                    {
                        // instrukcje stanopwisko i model
                        foreach (var idm in ModelsCheck)
                            JoinInforamtionPlain(idw, idd, idm);
                    }
                    else
                    {
                        // instrukcje stanowiskowe
                        JoinInforamtionPlain(idw, idd, null);
                    }
                }
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Błąd podczas zapisu " + ex.Message);
                ret = false;
            }
            return ret;
        }

        private bool JoinInforamtionPlain(Nullable<int> IdR, Nullable<int> IdD, Nullable<int> IdM)
        {
            if (IdR != null)
                if (IdD != null)
                {
                    if (db.Resource.Find(IdR) == null)
                        return false;
                    if (IdM.HasValue)
                        if (db.Resource.Find(IdM) == null)
                            return false;
                    if (db.Dokument.Find(IdD) == null)
                        return false;

                    // czy taki plan już istnieje
                    var exist = db.InformationPlan.Where(m => m.IdD == IdD.Value && m.idR == IdR.Value && m.IdM == IdM).Any();
                    if (!exist)
                    {
                        InformationPlan ip = new InformationPlan();
                        ip.Enabled = true;
                        ip.Order = 0;
                        ip.idR = IdR.Value;
                        ip.IdD = IdD.Value;
                        ip.IdM = IdM;


                        db.InformationPlan.Add(ip);
                    }
                    return true;
                }
            return false;

        }

    }
}

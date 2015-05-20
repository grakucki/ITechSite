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

namespace ITechSite.Controllers
{
    public class DokumentsController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

        // GET: Dokuments
        public ActionResult Index()
        {
            var dokument = db.Dokument.Include(d => d.FileContent).Include(d => d.WorkProcess);
            return View(dokument.ToList());
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
        public ActionResult Create([Bind(Include = "Id,FileName,CodeName,Enabled,Description,ValidDtmOn,ValidDtmOff,WorkProcess_Id,File")] Dokument dokument)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dokument.LastWriteTime = DateTime.Now;
                    dokument.FileType = Path.GetExtension(dokument.FileName);
                    if (dokument.File != null)
                    {
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
                }

                ViewBag.WorkProcess_Id = new SelectList(db.WorkProcess, "Id", "Name", dokument.WorkProcess_Id);
            }
            catch (DbEntityValidationException ex)
            {

                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
          
            return View(dokument);
        }

        public ActionResult Create2()
        {
            return View();
        }

        // POST: Dokuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create2( FileData dokument)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    if (dokument.File != null)
                    {
                        // zapisz plik
                    }
                    
                    return RedirectToAction("Index");
                }

            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
            catch (Exception ex)
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
            ViewBag.WorkProcess_Id = new SelectList(db.WorkProcess, "Id", "Name", dokument.WorkProcess_Id);
            return View(dokument);
        }

        // POST: Dokuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,SourceFileName,LastWriteTime,CodeName,Enabled,FileType,Description,ValidDtmOn,ValidDtmOff,FileContent_Id,WorkProcess_Id")] Dokument dokument)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dokument.LastWriteTime = DateTime.Now;
                    db.Entry(dokument).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.WorkProcess_Id = new SelectList(db.WorkProcess, "Id", "Name", dokument.WorkProcess_Id);
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
            catch (Exception ex)
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

    }
}

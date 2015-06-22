using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITechSite.Models;
using PagedList;

namespace ITechSite.Controllers
{
        [Authorize]
    public class ResourcesController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

        // GET: Resources
        public ActionResult Index(ResourceListFind rlf)
        {
            //var resource = db.Resource;//.Include(r=>r.ResourceType);
            if (rlf==null)
                rlf = new ResourceListFind();
            rlf.Fill(db);
            return View(rlf);
//            return View(resource.ToList());
        }

        public ActionResult Find(int? IdR, ResourceListFind rf)
        {
            var r = (ResourceListFind)TempData["ResourceListFind"];

            if (r != null)
            {
                rf = (ResourceListFind)TempData["ResourceListFind"];
            }

            if (IdR == null || IdR == 0)
            {
                rf.Fill(db);
                return View(rf);
            }


//            return RedirectToAction("Index", new { IdR = IdR });
            
            string decodedUrl = "";
            if (!string.IsNullOrEmpty(rf.ReturnUrl))
            {
                decodedUrl = Server.UrlDecode(rf.ReturnUrl);
                return Redirect(decodedUrl + "/" + IdR.ToString());
            }

            if (Url.IsLocalUrl(decodedUrl))
            {
                return Redirect(decodedUrl + "?" + "IdR=" + IdR.ToString());
            }

            return RedirectToAction("Index", "Home", new { IdR=IdR});

        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resource.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            AddViewBag();
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name,Type,LastWriteTime,No,WorkProcess,Enabled,Description,Keywords")] Resource resource)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    resource.LastWriteTime = DateTime.Now;
                    // sprawdzamy czy nazwa już istniej

                    db.Resource.Add(resource);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            AddViewBag();
            return View(resource);
        }

        private void AddViewBag()
        {
            ViewBag.WorkProcess = new SelectList(db.WorkProcess, "Name", "Name");
            ViewBag.Type = new SelectList(db.ResourceType, "Id", "Type");
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return  RedirectToAction("Index");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resource.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkProcess = new SelectList(db.WorkProcess, "Name", "Name", resource.WorkProcess);
            ViewBag.Type = new SelectList(db.ResourceType, "Id", "Type", resource.Type);

            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,No,WorkProcess,Enabled,Description,Keywords")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                resource.LastWriteTime = DateTime.Now;
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            AddViewBag();
            return View(resource);
        }

        public ActionResult Workstation(int? idR)
        {
            return RedirectToAction("Edit", "Workstations", new { idR = idR }); ;
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resource.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resource.Find(id);
            db.Resource.Remove(resource);
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
    }
}

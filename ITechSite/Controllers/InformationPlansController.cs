using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITechSite.Models;

namespace ITechSite.Controllers
{
    public class InformationPlansController : Controller
    {
        private ITechEntities db = new ITechEntities();

        // GET: InformationPlans
        public ActionResult Index(int? IdR)
        {
            if (IdR == null || IdR==0)
            {
                return RedirectToAction("SelectResources2");
            }

            var informationPlan = db.InformationPlan.Where(m => m.idR == IdR).OrderBy(m=>m.Order).Include(i => i.Dokument).Include(i => i.Resource);
            return View(informationPlan.ToList());
        }

//        public ActionResult SelectResources([Bind(Include = "IdR")] int? IdR)

        public ActionResult SelectResources(int? IdR)
        {
            if (IdR == null || IdR == 0)
            {
                ViewBag.IdR = new SelectList(db.Resource.Where(i => i.Enabled).OrderBy(i => i.Name), "Id", "Name");
                return View();
            }
            return RedirectToAction("Index", new { IdR = IdR });
        }

        public ActionResult SelectResources2(int? IdR, ResourceListFind rf)
        {
            if (IdR == null || IdR == 0)
            {
                if (rf == null)
                    rf = new ResourceListFind();
                ViewBag.WorkProcess = new SelectList(db.WorkProcess, "Name", "Name");
                rf.Fill(db);
                //rf.Resources = db.Resource.Where(i => i.Enabled).Where(i=>i.Name.IndexOf(rf.Find)>=0 | i.Description.IndexOf(rf.Find)>=0 | rf.Find == null).OrderBy(i => i.Name).ToList();
                return View(rf);
            }
            return RedirectToAction("Index", new { IdR = IdR });
        }


        // GET: InformationPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformationPlan informationPlan = db.InformationPlan.Find(id);
            if (informationPlan == null)
            {
                return HttpNotFound();
            }
            return View(informationPlan);
        }

        // GET: InformationPlans/Create
        public ActionResult Create(int? IdR)
        {
            ViewBag.IdD = new SelectList(db.Dokument, "Id", "FileName");
            ViewBag.idR = new SelectList(db.Resource, "Id", "Name", IdR);
            return View();
        }

        // POST: InformationPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdR,IdD,Order")] InformationPlan informationPlan)
        {
            if (ModelState.IsValid)
            {
                db.InformationPlan.Add(informationPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdD = new SelectList(db.Dokument, "Id", "FileName", informationPlan.IdD);
            ViewBag.idR = new SelectList(db.Resource, "Id", "Name", informationPlan.idR);
            return View(informationPlan);
        }

        // GET: InformationPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformationPlan informationPlan = db.InformationPlan.Find(id);
            if (informationPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdD = new SelectList(db.Dokument, "Id", "FileName", informationPlan.IdD);
            ViewBag.idR = new SelectList(db.Resource, "Id", "Name", informationPlan.idR);
            return View(informationPlan);
        }

        // POST: InformationPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,IdR,IdD,Order")] InformationPlan informationPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informationPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdD = new SelectList(db.Dokument, "Id", "FileName", informationPlan.IdD);
            ViewBag.idR = new SelectList(db.Resource, "Id", "Name", informationPlan.idR);
            return View(informationPlan);
        }

        // GET: InformationPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformationPlan informationPlan = db.InformationPlan.Find(id);
            if (informationPlan == null)
            {
                return HttpNotFound();
            }
            return View(informationPlan);
        }

        // POST: InformationPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformationPlan informationPlan = db.InformationPlan.Find(id);
            db.InformationPlan.Remove(informationPlan);
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

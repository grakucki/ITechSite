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
    public class WorkProcessesController : Controller
    {
        private ITechEntities db = new ITechEntities();

        // GET: WorkProcesses
        public ActionResult Index()
        {
            return View(db.WorkProcess.ToList());
        }

        // GET: WorkProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkProcess workProcess = db.WorkProcess.Find(id);
            if (workProcess == null)
            {
                return HttpNotFound();
            }
            return View(workProcess);
        }

        // GET: WorkProcesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WorkProcess workProcess)
        {
            if (ModelState.IsValid)
            {
                db.WorkProcess.Add(workProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workProcess);
        }

        // GET: WorkProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkProcess workProcess = db.WorkProcess.Find(id);
            if (workProcess == null)
            {
                return HttpNotFound();
            }
            return View(workProcess);
        }

        // POST: WorkProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WorkProcess workProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workProcess);
        }

        // GET: WorkProcesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkProcess workProcess = db.WorkProcess.Find(id);
            if (workProcess == null)
            {
                return HttpNotFound();
            }
            return View(workProcess);
        }

        // POST: WorkProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkProcess workProcess = db.WorkProcess.Find(id);
            db.WorkProcess.Remove(workProcess);
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

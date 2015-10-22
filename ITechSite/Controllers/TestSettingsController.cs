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
    [Authorize(Roles = "admin")]
    public class TestSettingsController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

        // GET: TestSettings
        public ActionResult Index()
        {
            var s = db.TestSettings.FirstOrDefault();
            if (s==null)
            {
                s = new TestSettings();
                s.Test_BlokOnValid = false;
                s.Test_PeriodDay = 30;
                db.TestSettings.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = s.id });
        }

        // GET: TestSettings/Details/5
        public ActionResult Details(int? id)
        {
            TestSettings testSettings = db.TestSettings.FirstOrDefault();
            if (testSettings == null)
            {
                return HttpNotFound();
            }
            return View(testSettings);
        }

        // GET: TestSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Test_PeriodDay,Test_BlokOnWalit")] TestSettings testSettings)
        {
            if (ModelState.IsValid)
            {
                db.TestSettings.Add(testSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testSettings);
        }

        // GET: TestSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            TestSettings testSettings = db.TestSettings.FirstOrDefault();
            if (testSettings == null)
            {
                return HttpNotFound();
            }
            return View(testSettings);
        }

        // POST: TestSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Test_PeriodDay,Test_BlokOnValid")] TestSettings testSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testSettings);
        }

        // GET: TestSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestSettings testSettings = db.TestSettings.Find(id);
            if (testSettings == null)
            {
                return HttpNotFound();
            }
            return View(testSettings);
        }

        // POST: TestSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestSettings testSettings = db.TestSettings.Find(id);
            db.TestSettings.Remove(testSettings);
            //db.SaveChanges();
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

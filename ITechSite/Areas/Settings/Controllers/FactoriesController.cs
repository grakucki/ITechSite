using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITechSite.Models;
using ITechSite.Areas.Settings.Models;

namespace ITechSite.Areas.Settings.Controllers
{
    [Authorize(Roles = "admin")]
    public class FactoriesController : Controller
    {
        private ITechEntities db = new ITechEntities();

        // GET: Settings/Factories
        public async Task<ActionResult> Index()
        {
            return View(await db.Factory.ToListAsync());
        }

        // GET: Settings/Factories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factory = await db.Factory.FindAsync(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        // GET: Settings/Factories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/Factories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.Factory.Add(factory);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = factory.Id });
            }

            return View(factory);
        }

        // GET: Settings/Factories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factory = await db.Factory.FindAsync(id);
            if (factory == null)
            {
                return HttpNotFound();
            }

            FactoriesEditViewModel model = new FactoriesEditViewModel(factory);
            model.AvailableProject = db.Department.AsEnumerable().Where(m=>!factory.Department.Contains(m)).ToList();
            model.AvailableWorkProcess = db.WorkProcess.AsEnumerable().Where(m => !factory.WorkProcess.Contains(m)).ToList();
            return View(model);
//            return View(factory);
        }

        // POST: Settings/Factories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(factory);
        }

        // GET: Settings/Factories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factory = await db.Factory.FindAsync(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        // POST: Settings/Factories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Factory factory = await db.Factory.FindAsync(id);
            db.Factory.Remove(factory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
        public async Task<ActionResult> AddProject(int id, int projectId, string act)
        {
            Factory factory = await db.Factory.FindAsync(id);

            if (act == "Remove")
            {
                Department project = factory.Department.Where(m=>m.Id== projectId).FirstOrDefault();
                if (project!=null)
                    factory.Department.Remove(project);
            }

            if (act == "Add")
            {
                Department project = db.Department.Find(projectId);
                //Department project = await db.Department.FindAsync(projectId);
                factory.Department.Add(project);
            }

            db.SaveChanges();
            return RedirectToAction("Edit", new { id = id });
        }


        public async Task<ActionResult> AddWorkProccess(int id, int workProcessId, string act)
        {
            Factory factory = await db.Factory.FindAsync(id);

            if (act == "Remove")
            {
                WorkProcess e = factory.WorkProcess.Where(m => m.Id == workProcessId).FirstOrDefault();
                if (e != null)
                    factory.WorkProcess.Remove(e);
            }

            if (act == "Add")
            {
                WorkProcess e = db.WorkProcess.Find(workProcessId);
                //Department project = await db.Department.FindAsync(projectId);
                factory.WorkProcess.Add(e);
            }

            db.SaveChanges();
            return RedirectToAction("Edit", new { id = id });
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

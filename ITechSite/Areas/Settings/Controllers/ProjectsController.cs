using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite.Areas.Settings.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Settings/Projects
        public ActionResult Index()
        {
            return View();
        }

        // GET: Settings/Projects/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Settings/Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/Projects/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Settings/Projects/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Settings/Projects/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Settings/Projects/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Settings/Projects/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

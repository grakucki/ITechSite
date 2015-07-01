using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITechSite.Models;
using System.Diagnostics;

namespace ITechSite.Controllers
{
    public class WorkstationsController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

        // GET: Workstations
        public ActionResult Index(int? idR)
        {

            return RedirectToAction("Details", new { idR = idR });
        }

        // GET: Workstations/Details/5
        public ActionResult Details(int? idR)
        {
            if (idR == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workstation workstation = db.Workstation.Where(mbox=>mbox.idR==idR).FirstOrDefault();
            if (workstation == null)
            {
                return RedirectToAction("Details", "Resources", new { id = idR });

            }
            return View(workstation);
        }

        // GET: Workstations/Create
        public ActionResult Create(int? idR)
        {
            ViewBag.WorkstationGroup = new SelectList(db.WorkstationGroup, "Name", "Name");
            ViewBag.idR = new SelectList(db.Resource.Where(m => m.Id == idR), "Id", "Name", idR);
            ViewBag.Sterownik_Model = new SelectList(db.SimaticCpuType, "CpuType", "CpuType");

            return View();
        }

        // POST: Workstations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkstationGroup,Factory,Area,idR,Sterownik_Ip,Sterownik_Model,Setrownik_DB")] Workstation workstation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    workstation.Area = "";
                    db.Workstation.Add(workstation);
                    db.SaveChanges();
                    return RedirectToAction("Edit", "Resources", new { idR = workstation.idR });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }

            ViewBag.WorkstationGroup = new SelectList(db.WorkstationGroup, "Name", "Name", workstation.WorkstationGroup);
            ViewBag.idR = new SelectList(db.Resource.Where(m => m.Id == workstation.idR), "Id", "Name", workstation.idR);


            ViewBag.Sterownik_Model = new SelectList(db.SimaticCpuType, "CpuType", "CpuType", workstation.Sterownik_Model);
            return View(workstation);
        }

        // GET: Workstations/Edit/5
        public ActionResult Edit(int? idR)
        {
            if (idR == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workstation workstation = db.Workstation.Where(mbox => mbox.idR == idR).FirstOrDefault();
            if (workstation == null)
            {
                return RedirectToAction("Create", new { idR = idR });
            }
            ViewBag.WorkstationGroup = new SelectList(db.WorkstationGroup, "Name", "Name", workstation.WorkstationGroup);
            ViewBag.idR = new SelectList(db.Resource.Where(m => m.Id == workstation.idR), "Id", "Name", workstation.idR);
            ViewBag.Sterownik_Model = new SelectList(db.SimaticCpuType, "CpuType", "CpuType", workstation.Sterownik_Model);


            return View(workstation);
        }

        // POST: Workstations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkstationGroup,Factory,Area,idR,Sterownik_Ip,Sterownik_Model,Setrownik_DB")] Workstation workstation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workstation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Resources", new { idR = workstation.idR });
            }
            ViewBag.WorkstationGroup = new SelectList(db.WorkstationGroup, "Name", "Name", workstation.WorkstationGroup);
            ViewBag.idR = new SelectList(db.Resource.Where(m => m.Id == workstation.idR), "Id", "Name", workstation.idR);
            ViewBag.Sterownik_Model = new SelectList(db.SimaticCpuType, "CpuType", "CpuType", workstation.Sterownik_Model);


            return View(workstation);
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

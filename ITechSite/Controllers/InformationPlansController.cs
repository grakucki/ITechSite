using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITechSite.Models;
using System.Web.Routing;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace ITechSite.Controllers
{
        [Authorize]
    public class InformationPlansController : Controller
    {
        private ITechEntities db = new ITechEntities();


//        public static string AbsoluteAction(this UrlHelper url, string actionName, string controllerName, object routeValues = null)
        public string MyAction()
        {

            return HttpUtility.UrlEncode(Request.Url.AbsoluteUri.ToString());
        }

        public XmlResult GetXml2(int? IdR)
        {
            //var informationPlan = db.InformationPlan.Where(m => m.idR == IdR).OrderBy(m => m.Order).Include(i => i.Dokument).Include(i => i.Resource).ToList();

            using (var d = new ITechEntities() )
            { 
                var doc = d.Resource.ToList();

                MemoryStream ms = new MemoryStream();
                using (XmlWriter writer = XmlWriter.Create(ms))
                {
                    //System.Runtime.Serialization.
                    DataContractSerializer serializer = new DataContractSerializer(d.GetType());
                    serializer.WriteObject(writer, d);
                }
                var sr = new StreamReader(ms);
                var myStr = sr.ReadToEnd();

                var ret = new XmlResult(d);
                return ret;
            }
            

        }
        
        public ActionResult GetXml(int? IdR)
        {
            if (IdR == null || IdR == 0)
            {
                var rf = new ResourceListFind();
                rf.ReturnUrl = MyAction();
                TempData["ResourceListFind"] = rf;
                return RedirectToAction("Find", "Resources");
            }

            //var informationPlan = db.InformationPlan.Where(m => m.idR == IdR).OrderBy(m => m.Order).Include(i => i.Dokument).Include(i => i.Resource);

            return GetXml2(IdR);
        }


        // GET: InformationPlans
        public ActionResult Index(int? IdR)
        {
            if (IdR == null || IdR==0)
            {
                var rf = new ResourceListFind();
                rf.ReturnUrl = MyAction();
                    
                //rf.ReturnUrl = "./InformationPlans/Index";
                TempData["ResourceListFind"] = rf;
                return RedirectToAction("Find", "Resources");
            }

            return GetXml(IdR);
            var informationPlan = db.InformationPlan.Where(m => m.idR == IdR).OrderBy(m=>m.Order).Include(i => i.Dokument).Include(i => i.Resource);
            return View(informationPlan.ToList());
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

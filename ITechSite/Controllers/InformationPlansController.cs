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
            private ITechEntities db = new ITechEntities(0);


//        public static string AbsoluteAction(this UrlHelper url, string actionName, string controllerName, object routeValues = null)
        public string MyAction()
        {

            return HttpUtility.UrlEncode(Request.Url.AbsoluteUri.ToString());
        }

        public XmlResult GetXml2(int? IdR)
        {
            //var informationPlan = db.InformationPlan.Where(m => m.idR == IdR).OrderBy(m => m.Order).Include(i => i.Dokument).Include(i => i.Resource).ToList();

            using (var d = new ITechEntities(0) )
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

            //return GetXml(IdR);
            var informationPlan = db.InformationPlan.Where(m => m.idR == IdR).OrderBy(m=>m.Order)
                .Include(i => i.Dokument).Include(i => i.Resource);
            ViewBag.Ret_idR = IdR;
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
            ViewBag.idR = informationPlan.idR;
            return View(informationPlan);
        }



        private void Create_FillData(InformationPlanModels ipm)
        {
            var IdR = ipm.idR;
            var IdM = ipm.IdM;
            ipm.Resource = db.Resource.Where(m => m.Id == IdR).FirstOrDefault();
            ipm.ResourceModel = db.Resource.Where(m => m.Id == IdM.Value).FirstOrDefault();
            ViewBag.idR = new SelectList(db.Resource.Where(m => m.Id == IdR), "Id", "Name", IdR);
            ViewBag.idM = new SelectList(db.Resource.Where(m => m.Id == IdM), "Id", "Name", IdM);

            var repo = new ITechSite.Models.Repository.DokumentRepository();
            ViewBag.Kategoria_Id = new SelectList(repo.GetKategorie(), "id", "name", ipm.Kategorie_Id);
            if (string.IsNullOrEmpty(ipm.WorkProcess))
                ipm.WorkProcess = ipm.Resource.WorkProcess;
            ipm.AvalibleWorkProcess = repo.GetWorkProcessAll().ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Name });
            ipm.IncludeDoc = repo.IncludeInformationPlainDoc(IdR, IdM);
            var docs = repo.GetAvalibleDoc(IdR, IdM, ipm.WorkProcess, ipm.CodeName, ipm.Kategorie_Id);
            ViewBag.IdD = new SelectList(docs, "Id", "FileName");
        }

        // GET: InformationPlans/Create
            /// <summary>
            /// 
            /// </summary>
            /// <param name="IdR">statnowisko</param>
            /// <param name="IdM">model</param>
            /// <returns></returns>
        public ActionResult Create(int IdR, int? IdM)
        {
            var informationPlan = new InformationPlanModels();
            informationPlan.idR = IdR;
            informationPlan.IdM = IdM;

            if (!informationPlan.IdM.HasValue)
                informationPlan.IdM = informationPlan.idR;

            if (informationPlan.idR == 0)
                informationPlan.idR = informationPlan.IdM.Value;



            Create_FillData(informationPlan);

            return View(informationPlan);
        }

        // POST: InformationPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "IdR,IdD,Order")] InformationPlan informationPlan)
        public ActionResult Create([Bind(Include = "IdR,IdD,IdM,Order,FindAction,CodeName,WorkProcess,Kategorie_Id")] InformationPlanModels informationPlan)
        {
            if (!informationPlan.IdM.HasValue)
                informationPlan.IdM = informationPlan.idR;

            if (informationPlan.idR == 0)
                informationPlan.idR = informationPlan.IdM.Value;

            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(informationPlan.FindAction))
                {
                    if (informationPlan.IdD != 0)
                    {
                        informationPlan.Enabled = true;
                        InformationPlan ip = new InformationPlan();
                        ip.Enabled = informationPlan.Enabled;
                        ip.IdD = informationPlan.IdD;
                        ip.IdM = informationPlan.IdM;
                        ip.idR = informationPlan.idR;


                        ip.Order = informationPlan.Order;
                        db.InformationPlan.Add(ip);
                        db.SaveChanges();
                        //return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("IdD", string.Format("Wybierz dokument do dodania"));

                    }
                }
            }
            Create_FillData(informationPlan);
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
            ViewBag.idR = new SelectList(db.Resource.Where(m => m.Id == informationPlan.idR), "Id", "Name", informationPlan.idR);
            ViewBag.Ret_idR = informationPlan.idR;
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
            ViewBag.idR = new SelectList(db.Resource.Where(m => m.Id == informationPlan.idR), "Id", "Name", informationPlan.idR);
            ViewBag.Ret_idR = informationPlan.idR;
            return View(informationPlan);
        }


        private ResourceListFind GetOrDefault()
        {
            var rf = (ResourceListFind)Session["ResourceListFind"];
            if (rf != null)
                return rf;
            return new ResourceListFind();
        }

        private void SetDefault(ResourceListFind rlf)
        {
            Session["ResourceListFind"] = rlf;
        }

        public ActionResult Edit2(ResourceListFind rf)
        {
            if (rf == null)
                rf = GetOrDefault();
            else
                if (rf.FindAction == null)
                    rf = GetOrDefault();
                else
                    SetDefault(rf);
            rf.Fill(db);
            return View(rf);
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
            var idr = informationPlan.idR;
            var idm = informationPlan.IdM;

            db.InformationPlan.Remove(informationPlan);
            db.SaveChanges();
            return RedirectToAction("Create", new { IdR= idr, IdM=idm });
        }

        // POST: InformationPlans/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    InformationPlan informationPlan = db.InformationPlan.Find(id);
        //    db.InformationPlan.Remove(informationPlan);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

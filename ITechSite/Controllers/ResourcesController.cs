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
using ITechSite.Custom;
using Nati;

namespace ITechSite.Controllers
{
    [Authorize(Roles="admin")]
    public class ResourcesController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

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

        //[HttpGet]
        //public ActionResult Index(ResourceListFind rf)
        //{
        //    var rlf = GetOrDefault(null);
        //    rlf.Fill(db);
        //    return View(rlf);
        //}

        // GET: Resources
        //[HttpPost]
        public ActionResult Index2()
        {
            ResourceListFind rf = GetOrDefault();
            return RedirectToAction("Index", new { rf = rf });
        }

        public ActionResult SetValid(string msg, bool CultureInfo=false)
        {
            var ll = new ModelL();
            var d = DateTime.Parse(msg);
            @ViewBag.Message = ll.SetValid(msg, CultureInfo);
            return View();
        } 

         
        public ActionResult Index(ResourceListFind rf)
        {
            if (rf == null)
                rf = GetOrDefault();  
            else
                if (rf.FindAction == null)
                    rf = GetOrDefault();
                else
                    SetDefault(rf);
            rf.Allow_ResourceType = true;
            rf.Fill(db);
            return View(rf);
        }

        public ActionResult Find(int? IdR, ResourceListFind rf)
        {
            var r = (ResourceListFind)TempData["ResourceListFind"];
                //(ResourceListFind)TempData["ResourceListFind"];


            if (r != null)
            {
                rf = (ResourceListFind)TempData["ResourceListFind"];
            }
            //rf.Allow_ResourceType = false;

            if (IdR == null || IdR == 0)
            {
                //rf.Find_ResourceType = db.ResourceType.Find(1).Type;
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

        public ActionResult Models(int? idR)
        {
            @ViewBag.WorkstationName = "";
           var w = db.Resource.Where(m=>m.Id==idR).FirstOrDefault();
           if (w != null)
               @ViewBag.Workstation = w;
            return View(db.Resource.Where(m => m.Enabled == true && m.Type == 2).OrderBy(m=>m.Name).ToList());
        }

        public ActionResult WorkstationModelsUpdate(int? idW, int? idM, bool remove=false)
        {
            try
            {
                var mod = db.ModelsWorkstation.Where(m => m.idM == idM.Value & m.idW == idW.Value).FirstOrDefault();
                if (remove)
                {   
                    // usuwamy model z workstation
                    if (mod != null)
                    {
                        db.ModelsWorkstation.Remove(mod);
                        db.SaveChanges();
                    }
                }
                else
                {
                    // dodajemy model do workstation
                    if (mod == null)
                    {
                        mod = new ModelsWorkstation { idW = idW.Value, idM = idM.Value, index = "" };
                        db.ModelsWorkstation.Add(mod);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {
                
            }

            return RedirectToAction("Models", new { idR = idW });
        }

        public ActionResult CreateVersionModel(int? type, int? Parent)
        {
            @ViewBag.Parent = Parent;
            return Create(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVersionModel([Bind(Include = "Id, Name,Type,LastWriteTime,No,Enabled,Description,Keywords")] Resource resource, int? Parent)
        {
            @ViewBag.Parent = Parent;
            var RParent = db.Resource.Find(Parent);
            if (RParent == null)
                return HttpNotFound();
            resource.ResourceModelParent.Add(RParent);

            if (_Create(resource))
                return RedirectToAction("Edit", new { id=Parent});
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create(int? type)
        {
            AddViewBag();
            var r = new Resource();
            if (type.HasValue)
                if (type > 0 && type < 4)
                    r.Type = type.Value;
                else
                    r.Type = 1;
            else
                r.Type = 1;
            r.Enabled = true;
            
            // jeśli model to nie ustawiamy 
            if (r.Type > 1)
            {
                r.Factory = ".";
                r.WorkProcess = ".";
            }
            return View(r);
        }


        private bool _Create(Resource resource)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    int min = 11;
                    resource.LastWriteTime = DateTime.Now;
                    // sprawdzamy czy nazwa już istniej
                    if (db.Resource.Where(m => m.Name == resource.Name).Any())
                        ModelState.AddModelError("Name", string.Format("Nazwa {0} jest już zajęta", resource.Name));
                    else
                    {
                        if (resource.Type != 1)
                        {
                            resource.Factory = null;
                            resource.WorkProcess = "";
                        }
                        if (resource.Description == null)
                            resource.Description = string.Empty;
                        if (resource.Keywords == null)
                            resource.Keywords = string.Empty;
                        
                        if (resource.Type==1)
                        {
                            int cnt=db.Resource.Where(m => m.Type == 1).Count();
                            if (cnt>min*3)
                                throw new ArgumentException(string.Format("Przekroczono limit licencji. Nie można utworzyć wiecej niż {0} stanowiska", cnt));
                        }

                        db.Resource.Add(resource);
                        db.SaveChanges();
                        return true;
                    }
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
            return false;
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name,Type,LastWriteTime,No,WorkProcess,Enabled,Description,Keywords,Factory")] Resource resource)
        {
            if (_Create(resource))
                return RedirectToAction("Index");
            return View(resource);
        }

        private void AddViewBag(Resource resource=null)
        {

            var repo = new FactoryRepository();
            //ViewBag.Type = new SelectList(db.ResourceType, "Id", "Type", resource == null ? 1 : resource.Type);
            
            ViewBag.Factory = new SelectList(repo.GetFactoryAll(), "Name", "Name", resource == null ? null : resource.Factory);
            ViewBag.WorkProcess = new SelectList(
                repo.GetWorkProcessBy(resource == null ? null : resource.Factory, null),
            "Name", "Name", resource == null ? null : resource.WorkProcess);

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

            AddViewBag(resource);
            //ViewBag.Factory = new SelectList(repo.GetFactoryAll(), "Name", "Name", resource.Factory);
            //ViewBag.WorkProcess = new SelectList(repo.GetWorkProcessBy(resource.Factory, null), "Name", "Name", resource.WorkProcess);

            //ViewBag.Factory = new SelectList(db.Factory, "Name", "Name", resource.Factory);
            //ViewBag.WorkProcess = new SelectList(db.WorkProcess, "Name", "Name", resource.WorkProcess);
            //ViewBag.Type = new SelectList(db.ResourceType, "Id", "Type", resource.Type);

            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,No,WorkProcess,Enabled,Description,Keywords,Factory,Type,LastWriteTime")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                var x = db.Resource.Where(m => m.Id == resource.Id).FirstOrDefault();
                if (x != null)
                {
                    x.LastWriteTime = DateTime.Now;
                    x.Name = resource.Name;
                    x.No = resource.No;
                    x.WorkProcess = resource.WorkProcess ?? "";
                    x.Enabled = resource.Enabled;
                    x.Description = resource.Description;
                    x.Keywords = resource.Keywords;
                    x.Factory = resource.Factory;
                    db.SaveChanges();
                }
               
                //db.Entry(resource).State = EntityState.Modified;
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
            // sprawdzenie czy zasób można usunąć
            @ViewBag.DontDelete = CanDelete(resource);
            
            return View(resource);
        }

        private string CanDelete(Resource resource)
        {
            string msg = string.Empty;
            if (resource.InformationPlan.Count() > 0)
                msg = "InformationPlan, ";
            if (resource.InformationPlanModel.Count() > 0)
                msg = "InformationPlanModel, ";

            if (!string.IsNullOrEmpty(msg))
            {
                msg = "Nie mogę usunąć ponieważ obiekt jest w użyciu przez " + msg;
            }
            return msg;
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resource.Find(id);

            // usuwamy news
            if (resource.News!=null)
                db.News.Remove(resource.News);

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

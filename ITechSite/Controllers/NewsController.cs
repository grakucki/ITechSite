using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ITechSite.Models
{
    [Authorize]
    public class NewsController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

        // GET: News
        [HttpGet]
        public ActionResult Index(string NewNews, DateTime? ValidEnd, string filter)
        {
            //var workstation = db.Resource.Where(m => m.Type == 1 && m.Enabled == true).OrderBy(m => m.Name).Select(new SelectedResources { Resource = m });
            var news = (from n in db.Resource where n.Type == 1 && n.Enabled == true orderby n.Name select new SelectedResources { Resource = n }).ToList();
            //if (actionChk!=null)
            //{
            //    foreach (var item in news)
            //    {
            //        var i = Array.IndexOf(actionChk, item.Resource.Id.ToString());

            //        if (i >= 0)
            //            item.Selected2 = true;
            //    }
            //}
            return View(news);
        }

        [HttpPost]
        public ActionResult Index(string NewNews, DateTime? ValidEnd, string[] actionChk)
        {
            //var workstation = db.Resource.Where(m => m.Type == 1 && m.Enabled == true).OrderBy(m => m.Name).Select(new SelectedResources { Resource = m });
            // zapisujemy do bazy
            if (actionChk == null)
            {
                ModelState.AddModelError("Error", "Zaznacz stanowiska na które chcesz wysłać komunikat.");
            }
            else
            {
                foreach (var item in actionChk)
                {
                    int idr = 0;
                    if (int.TryParse(item, out idr))
                    {
                        InsertNews(NewNews, ValidEnd, idr);
                    }
                }
            }

            var news = (from n in db.Resource where n.Type == 1 && n.Enabled == true orderby n.Name select new SelectedResources { Resource = n }).ToList();
            if (actionChk != null)
            {
                foreach (var item in news)
                {
                    var i = Array.IndexOf(actionChk, item.Resource.Id.ToString());

                    if (i >= 0)
                    {
                        item.Selected2 = true;
                    }
                }
                try
                {
                    db.SaveChanges();

                }
                catch (Exception /*ex*/)
                {

                }

            }
            return View(news);
        }
        private void InsertNews(string msg, DateTime? ValidEnd, int idR)
        {
            var q = db.Resource.Find(idR);
            if (q.News == null)
            {
                q.News = new News();
            }
            q.News.News1 = msg;
            q.News.ValidEnd = ValidEnd;
            
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        
    }
}

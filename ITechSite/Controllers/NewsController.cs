using ITechSite.Custom;
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
        public ActionResult Index(string NewNews, DateTime? ValidEnd, string filter, int? priority)
        {
            if (!priority.HasValue)
                priority = 1;

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

            @ViewBag.priority = new SelectList(db.NewsPriority, "id", "Name", priority);

            var x = db.NewsPriority.ToList().Select(m => new ITechSite.Custom.ExtendedSelectListItem { Text = m.Name, Value = m.id.ToString(), htmlAttributes=new { @class = m.CssName } }).ToList();
            @ViewBag.priority2 = x;

            return View(news);
        }

        [HttpPost]
        public ActionResult Index(string NewNews, DateTime? ValidEnd, string[] actionChk, int? priority)
        {
            //var workstation = db.Resource.Where(m => m.Type == 1 && m.Enabled == true).OrderBy(m => m.Name).Select(new SelectedResources { Resource = m });
            // zapisujemy do bazy
            if (!priority.HasValue)
                priority = 1;

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
                        InsertNews(NewNews, ValidEnd, idr, priority);
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
            @ViewBag.priority = new SelectList(db.NewsPriority, "id", "Name", priority);
            var x = db.NewsPriority.ToList().Select(m => new ITechSite.Custom.ExtendedSelectListItem { Text = m.Name, Value = m.id.ToString(), htmlAttributes = new { @class = m.CssName }, Selected = priority.Value==m.id }).ToList();
            @ViewBag.priority2 = x;

            return View(news);
        }
        private void InsertNews(string msg, DateTime? ValidEnd, int idR, int? priority)
        {
            var q = db.Resource.Find(idR);
            if (q.News == null)
            {
                q.News = new News();
            }
            q.News.News1 = msg;
            q.News.ValidEnd = ValidEnd;
            q.News.NewsPriorityId = priority.Value;
            
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
        
        public ActionResult Test()
        {
            return View();
        }
        
    }
}

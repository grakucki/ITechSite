﻿using ITechSite.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace ITechSite.Models
{
    [Authorize]
    public class NewsController : Controller
    {
        private ITechEntities db = new ITechEntities(0);

        // GET: News
        [HttpGet]
        public ActionResult Index(string NewNews, DateTime? ValidEnd, string filter, int? priority, ResourceListFind rf)
        {

            if (!priority.HasValue)
                priority = 1;

            var r = ResourceListFind.From(rf);
            r.Allow_ResourceType = false;
            r.Fill(db);
            ViewBag.FindResources = r;

            var news = r.GetWorkstations(db).Select(m => new SelectedResources { Resource = m, Selected2=true }).ToList();

            //var news = (from n in db.Resource where n.Type == 1 && n.Enabled == true orderby n.Name select new SelectedResources { Resource = n }).ToList();

            @ViewBag.priority = new SelectList(db.NewsPriority, "id", "Name", priority);

            var x = db.NewsPriority.ToList().Select(m => new ITechSite.Custom.ExtendedSelectListItem { Text = m.Name, Value = m.id.ToString(), htmlAttributes=new { @class = m.CssName } }).ToList();
            @ViewBag.priority2 = x;

            ViewBag.FindResources = r;

            return View(news);
        }

        [HttpPost]
        [AuthorizeI]
        public ActionResult Index(string NewNews, DateTime? ValidEnd, string[] actionChk, int? priority, ResourceListFind rf)
        {
            if (!priority.HasValue)
                priority = 1;


            var r = ResourceListFind.From(rf);
           
            if (r.FindAction == "Send")
            {
                if (actionChk == null)
                {
                    ModelState.AddModelError("Error", "Zaznacz stanowiska na które chcesz wysłać komunikat.");
                }
                else
                {
                    var newNewsItem= CreateNewsItem(NewNews, ValidEnd, priority);
                    

                    foreach (var item in actionChk)
                    {
                        int idr = 0;
                        if (int.TryParse(item, out idr))
                        {
                            InsertNews(newNewsItem, idr);
                            //InsertNews(NewNews, ValidEnd, idr, priority);
                        }
                    }
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            r.SetAsDefault();
            r.Allow_ResourceType = false;
            r.Fill(db);
            ViewBag.FindResources = r;

            var news = r.GetWorkstations(db).Select(m => new SelectedResources { Resource = m}).ToList();
            //var news = (from n in db.Resource 
            //            where n.Type == 1 && n.Enabled == true 
            //            orderby n.Name select new SelectedResources { Resource = n }).ToList();

            foreach (var item in news)
            {
                if (r.FindAction != "Szukaj")
                {
                    if (actionChk != null)
                        if (Array.IndexOf(actionChk, item.Resource.Id.ToString()) >= 0)
                            item.Selected2 = true;
                }
                else
                    item.Selected2 = true;
            }
            
            
            @ViewBag.priority = new SelectList(db.NewsPriority, "id", "Name", priority);
            var x = db.NewsPriority.ToList().Select(m => new ITechSite.Custom.ExtendedSelectListItem { Text = m.Name, Value = m.id.ToString(), htmlAttributes = new { @class = m.CssName }, Selected = priority.Value==m.id }).ToList();
            @ViewBag.priority2 = x;


            return View(news);
        }

        private NewsItems CreateNewsItem(string NewNews, DateTime? ValidEnd, int? priority)
        {
            var newItem = new NewsItems();
            newItem.NewsText = NewNews;
            newItem.ValidEnd = ValidEnd;
            newItem.CreateAt = DateTime.Now;
            newItem.CreateBy = User.Identity.GetUserId();
            newItem.NewsPriorityId = priority.Value;
            db.NewsItems.Add(newItem);
            db.SaveChanges();
            return newItem;
        }
        private void InsertNews(string msg, DateTime? ValidEnd, int idR, int? priority)
        {
            var q = db.Resource.Find(idR);
            if (q != null)
            {
                if (q.News == null)
                {
                    q.News = new News();
                }
                q.News.News1 = msg;
                q.News.ValidEnd = ValidEnd;
                q.News.NewsPriorityId = priority.Value;

                q.News.CreatedAt = DateTime.Now;
            }
        }

        private void InsertNews(NewsItems item, int idR)
        {
            var q = db.Resource.Find(idR);
            if (q != null)
            {
                if (q.News == null)
                {
                    q.News = new News();
                }
                q.News.News1 = item.NewsText;
                q.News.ValidEnd = item.ValidEnd;
                q.News.NewsPriorityId = item.NewsPriorityId;
                q.News.CreatedAt = item.CreateAt;
                q.News.NewsItems = item;
            }
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

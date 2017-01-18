using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using ITechSite.Models;
using System.Data.Entity.Validation;
using System.IO;
using PagedList;
using System.Web.Security;
//using ITechSite.Models.Repository.ItechUsersImport;

namespace ITechSite.Models.Repository
{
    public class ItechUsersRepository
    {
        private ITechEntities _dataContex;

        public ItechUsersRepository()
        {
            _dataContex = new ITechEntities(0);
        }

        public IQueryable<ItechUsers> Find(string userName, string identityNo)
        {
            var x = _dataContex.ItechUsers.AsQueryable();
            var order = "name";

            x = x.Where(m => m.Deleted == false);
            if (!string.IsNullOrEmpty(userName))
                x = x.Where(m => m.UserName.Contains(userName));
            else
                order = "id";

            if (!string.IsNullOrEmpty(identityNo))
            {
                x = x.Where(m => m.CardNo.Contains(identityNo) || m.UserId.Contains(identityNo));
            }

            if (order == "name")
                x = x.OrderBy(m => m.UserName);
            else
                x = x.OrderBy(m => m.CardNo);
            return x;
        }

        public ItechUsers CreateUser(ItechUsers User)
        {
            var r = _dataContex.AspNetRoles.Where(m => m.Name.Equals("pracownik")).FirstOrDefault();
            var x = _dataContex.ItechUsers.Add(User);

            if (r != null)
                User.AspNetRoles.Add(r);
            _dataContex.SaveChanges();
            return x;
        }

        public ItechUsers GetUser(int id)
        {
            var x = _dataContex.ItechUsers.Find(id);
            return x;
        }

        public void Update(ItechUsers user)
        {
            //_dataContex.Entry(user).State = EntityState.Modified;
            var u = _dataContex.ItechUsers.Find(user.id);
            if (u == null)
                return;
            u.UserId = user.UserId;
            u.UserName = user.UserName;
            u.CardNo = user.CardNo;
            if (!string.IsNullOrEmpty(user.Password))
                u.Password = user.Password;
            u.Frozen = user.Frozen;
            u.Enabled = user.Enabled;
            u.Desc = user.UserId;
            u.AccessProfile = user.AccessProfile;
            u.ForceTestKompetencji = user.ForceTestKompetencji;
            _dataContex.SaveChanges();
        }


        public List<SelectedItem> GetAllRoles()
        {
            return _dataContex.AspNetRoles.Select(m => new SelectedItem { Id = m.Id, Name = m.Name }).ToList();
        }

        public string GetLastAccessionNumber(int? id)
        {
            if (!id.HasValue)
                return null;

            var r = _dataContex.TestKompetencji.Where(m => m.UserId == id).OrderByDescending(m=>m.createdAt).Select(m=>m.accessionNumber).FirstOrDefault();
            return r;
        }


        internal void ChangeRoles(int id, string[] SelectedRoles)
        {
            var u = GetUser(id);
            u.AspNetRoles.Clear();
            if (SelectedRoles != null)
            {
                foreach (var item in SelectedRoles)
                {
                    var r = _dataContex.AspNetRoles.Find(item);
                    if (r != null)
                    {
                        u.AspNetRoles.Add(r);
                    }
                }
            }
            _dataContex.SaveChanges();
        }

        public ItechUserActivityReadingModel GetActivity(ItechUserActivityReadingModel activity)
        {
            if (!activity.page.HasValue)
                activity.page = 1;

            var filter = activity.FText;

            var u = _dataContex.ItechUsers.Find(activity.UserId);
            if (u == null)
                return activity;

            IQueryable<ActivityReadingItem> items = null;

            if (activity.Type == 'N')
            {
                var o = u.ItechUsersNewsRead.AsQueryable();

                if (!string.IsNullOrEmpty(activity.FText))
                    o = o.Where(m => m.NewsItems.NewsText.Contains(activity.FText));

                items = o.Select(m => new ActivityReadingItem()
                {
                    id = m.NewsItemId,
                    Type = activity.Type,
                    FirstReadAt = m.FirstReadAt,
                    LastReadAt = m.LastReadAt,
                    ReadCount = m.ReadCount,
                    Text = m.NewsItems.NewsText
                }).OrderByDescending(m => m.FirstReadAt);


            }
            else
            {
                var o = u.ItechUsersDokumentRead.AsQueryable();

                //var o = _dataContex.ItechUsersDokumentRead.Where(m => m.UserId ==activity.UserId.Value).AsQueryable();

                if (!string.IsNullOrEmpty(activity.FText))
                    o = o.Where(m => m.Dokument.CodeName.Contains(activity.FText) || m.Dokument.FileName.Contains(activity.FText)
                        || ( !string.IsNullOrEmpty(m.Dokument.Description) &&  m.Dokument.Description.Contains(activity.FText) ));
//                o = o.Where(m => m.Dokument.CodeName.Contains(activity.FText) || m.Dokument.FileName.Contains(activity.FText) || m.Dokument.Description.Contains(activity.FText));
                var xx = o.Count();

                items = o.Select(m => new ActivityReadingItem()
                    {
                        id = m.DokId,
                        Type = 'D',
                        FirstReadAt = m.FirstReadAt,
                        LastReadAt = m.LastReadAt,
                        ReadCount = m.ReadCount,
                        Text = string.Concat(m.Dokument.CodeName, " ", m.Dokument.Description, " (ver: "+ m.DokVersion+ ")")
                    }).OrderByDescending(m => m.FirstReadAt);
            }

            activity.ActivityList = items.ToPagedList(activity.page.Value, 20);
            activity.ItechUser = u;
            activity.PageCount = activity.ActivityList.PageCount;
            return activity;
        }
    }

    public class ItechUserIndexModel
    {

        public IPagedList<ItechUsers> Users { get; set; }
        public int? page { get; set; }
        public string UserName { get; set; }
        public string IdentityNo { get; set; }
    }


    public class AccountIndexModel
    {
        public List<ApplicationUser> Users { get; set; }
        public int? page { get; set; }
        public string UserName { get; set; }
        public string IdentityNo { get; set; }
    }


    public class ActivityReadingItem
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public char Type { get; set; }
        public DateTime? FirstReadAt { get; set; }
        public DateTime? LastReadAt { get; set; }
        public int ReadCount { get; set; }
        public string Text { get; set; }
    }

    public class ItechUserActivityReadingModel
    {
        public IPagedList<ActivityReadingItem> ActivityList { get; set; }
        public ItechUsers ItechUser { get; set; }
        public char Type { get; set; }
        public int? page { get; set; }
        public int? PageCount { get; set; }
        public int? UserId { get; set; }
        public string FText { get; set; }
    }

    
    public class AccountEditModel
    {
        public ApplicationUser User { get; set; }
        // lista  roli w który user jest zarejestrowany
        public string[] UserRoles { get; set; }
        // lista dostępnych roli w który user nie jest zarejestrowany
        public List<string> AllowRoles { get; set; }
    }

    public class SelectedItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


}


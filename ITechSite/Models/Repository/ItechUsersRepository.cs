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
            if (!string.IsNullOrEmpty(userName))
                x = x.Where(m=>m.UserName.Contains(userName));
            else
                order = "id";
            if (!string.IsNullOrEmpty(identityNo))
                x = x.Where(m => m.CardNo.Contains(identityNo));

            if (order == "name")
                x = x.OrderBy(m => m.UserName);
            else
                x = x.OrderBy(m => m.CardNo);
            return x;
        }

        public ItechUsers GetUser(int id)
        {
            var x = _dataContex.ItechUsers.Find(id);
            return x;
        }

        public void Update(ItechUsers user)
        {
            _dataContex.Entry(user).State = EntityState.Modified;
            _dataContex.SaveChanges();
        }

    }

    public class ItechUserIndexModel
    {
      
        public IPagedList<ItechUsers> Users{ get; set; }
        public int? page { get; set; }
        public string UserName { get; set; }
        public string IdentityNo { get; set; }
    }
}
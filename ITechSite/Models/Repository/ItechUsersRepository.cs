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
using ITechSite.Models.Repository.ItechUsersImport;

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
            var r = _dataContex.AspNetRoles.Where(m=>m.Name.Equals("pracownik")).FirstOrDefault();
            var x = _dataContex.ItechUsers.Add(User);

            if (r!=null)
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
            _dataContex.Entry(user).State = EntityState.Modified;
            _dataContex.SaveChanges();
        }


        public List<SelectedItem> GetAllRoles()
        {
            return _dataContex.AspNetRoles.Select(m => new SelectedItem{ Id = m.Id, Name = m.Name }).ToList();
        }


        internal void ChangeRoles(int id, string[] SelectedRoles)
        {
            var u = GetUser(id);
            u.AspNetRoles.Clear();
            if (SelectedRoles!=null)
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
    }

    public class ItechUserIndexModel
    {
      
        public IPagedList<ItechUsers> Users{ get; set; }
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
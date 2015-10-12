﻿using ITechSite.Models;
using ITechSite.Models.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;

namespace ITechSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class ItechUsersController : Controller
    {
        // GET: ItechUsers

        //********* pracownicy **************************************************************************
#region pracownicy

        public ActionResult Index(ItechUserIndexModel userModel)
        {
            if (userModel == null)
                userModel = new ItechUserIndexModel();

            if (ModelState.IsValid)
            {
                var r = new ItechUsersRepository();
                if (!userModel.page.HasValue)
                    userModel.page = 1;
                userModel.Users = r.Find(userModel.UserName, userModel.IdentityNo).ToPagedList(userModel.page.Value, 10);
            }
            return View(userModel);
        }



        [HttpGet]
        public ActionResult Create()
        {
            var u = new ItechUsers();
            u.Enabled = true;
            return View(u);
        }
         
        [HttpPost]
        public ActionResult Create(ItechUsers user)
        {
            if (ModelState.IsValid)
            {
                var r = new ItechUsersRepository();
                r.CreateUser(user);

                // dodaj usera do grupy pracowników
                int id =user.id;
                return RedirectToAction("Edit", new { id = id });
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var r = new ItechUsersRepository();
            var u = r.GetUser(id.Value);
            if (u == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            @ViewBag.AllRoles = r.GetAllRoles();
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit(ItechUsers user)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var r = new ItechUsersRepository();
            r.Update(user);


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditRole(int id, string[] SelectedRoles)
        {
            var r = new ItechUsersRepository();
            r.ChangeRoles(id, SelectedRoles);
            return RedirectToAction("Edit", new {id =id });
        }

        // GET: ItechUsers
        [HttpGet]
        public ActionResult Import()
        {
            Session["ItechUsersImport"] = null;
            var d = new ItechUsersImport();
            ViewBag.step = 0;

            return View(d);
        }
        


        [HttpPost]
        public ActionResult Import(ItechUsersImport ImportFile, int? step)
        {

            if (!step.HasValue)
                step=0;

            if (step == 0)
            {
                if (ImportFile.File != null)
                {
                    using (StreamReader sr = new StreamReader(ImportFile.File.InputStream))
                    {
                        string f = sr.ReadToEnd();
                        Session["ItechUsersImport"] = f;
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Podaj plik");
                    ImportFile.MsgError = "Podaj plik.";
                    ViewBag.step = step;
                    return View(ImportFile);
                }
           }

            if (step==2)
                return RedirectToAction("Index");




            string data = (string)Session["ItechUsersImport"];
            if (string.IsNullOrEmpty(data))
            {
                ImportFile.FileName = "";
                step=0;
                ModelState.AddModelError("File", "Podaj poprawny plik");
                ImportFile.MsgError = "Podaj poprawny plik.";
            }
            else
            {
                switch (step)
                {
                    case 0:
                        if (FileIsValid(data, ImportFile))
                        {
                            step = 1;
                            ImportFile.MsgOk = "Plik poprawny kliknij zapisz aby wrowadzić zmiany.";
                        }
                        else
                            ImportFile.MsgError = "Popraw błędy i wczytaj plik ponownie.";
                        break;
                    case 1:
                        Session["ItechUsersImport"] = null;
                        ImportFile.MsgOk = "Zmiany wprowadzono pomyślnie.";
                        step = 2;
                        break;
                    case 2:
                        return RedirectToAction("Index");
                    default:
                        return RedirectToAction("Index");
                }
            }
            ViewBag.step = step;
            return View(ImportFile);
        }

        private bool FileIsValid(string data, ItechUsersImport ImportFile)
        {
            if (data.Length > 500)
                return true;

            ImportFile.ErrorItem = new List<string>();
            ImportFile.ErrorItem.Add("Błąd nr 1");
            ImportFile.ErrorItem.Add("Błąd nr 2");
            ImportFile.ErrorItem.Add("Błąd nr 3");
            ImportFile.ErrorItem.Add("Błąd nr 4");
            ImportFile.ErrorItem.Add("Błąd nr 5");
            return false;
        }


        public ActionResult ShowRoles(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var r = new ItechUsersRepository();
            var u = r.GetUser(id.Value);
            if (u == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            @ViewBag.AllRoles = r.GetAllRoles();
            return View(u);
        }
#endregion

        //***** konta serwisu www ***********************************************************************
        #region Accounts

        public ActionResult Accounts(ITechSite.Models.Repository.AccountIndexModel userModel)
        {
            if (userModel == null)
                userModel = new AccountIndexModel();
            if (string.IsNullOrEmpty(userModel.UserName))
                userModel.UserName = "";

            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    var users = userManager.Users.OrderBy(m => m.UserName);

                    userModel.Users = users.ToList();
                }
            }
            return View(userModel);
        }


        public ActionResult EditAccount(string UserName)
        {

            var b = System.Web.Security.Roles.Enabled;
            if (string.IsNullOrEmpty(UserName))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var r = new AccountEditModel();

            using (var context = new ApplicationDbContext())
            {

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var u = userManager.FindByName(UserName);
                if (u == null)
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                r.User = u;
                r.UserRoles = userManager.GetRoles(u.Id).OrderBy(m => m).ToArray();


                var roleStore = new Microsoft.AspNet.Identity.EntityFramework.RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var rr = roleManager.Roles.OrderBy(m => m.Name).ToList(); ;
                r.AllowRoles = new List<string>();
                foreach (var item in rr)
                { 
                    if (!userManager.IsInRole(u.Id, item.Name))
                        r.AllowRoles.Add(item.Name);
                }

            }
            return View(r);
        }

        public ActionResult EditUserRole(string UserName, string RoleName, string Act)
        {
            using (var context = new ApplicationDbContext())
            {

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };

                var u = userManager.FindByName(UserName);
                if (u == null)
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                if (Act == "Add")
                {
                    var x = userManager.AddToRole(u.Id, RoleName);
                    var rs = x.ToString(); 
                }
                if (Act == "Remove")
                    userManager.RemoveFromRole(u.Id, RoleName);

            }
            return RedirectToAction("EditAccount", new { UserName = UserName });
        }
    }
        #endregion
}
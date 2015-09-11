using ITechSite.Models;
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
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ITechSite.Controllers
{
    [Authorize]
    public class ItechUsersController : Controller
    {
        // GET: ItechUsers
        

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
                r.UserRoles = userManager.GetRoles(u.Id).OrderBy(m=>m).ToArray();
                

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

       

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var r = new ItechUsersRepository();
            var u = r.GetUser(id.Value);
            if (u==null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

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






        // GET: ItechUsers
        public ActionResult Import()
        {
            return View();
        }

    }
}
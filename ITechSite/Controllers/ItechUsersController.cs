using ITechSite.Models;
using ITechSite.Models.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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
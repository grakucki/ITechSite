﻿using ITechSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite.Controllers
{
    [Authorize]
    public class FactoryController : Controller
    {
        // GET: Factory
        public ActionResult Index()
        {
            return View();
        }

        private FactoryRepository _repository;

        public FactoryController()
            : this(new FactoryRepository())
        {
        }


        public FactoryController(FactoryRepository repository)
        {
            _repository = repository;
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentsByFactoryId(string Factory)
        {
            if (Factory == null && Factory.Equals("*"))
                Factory = null;

            var dep = _repository.GetDepartmentByFactoryName(Factory);

            var result = (from s in dep
                          select new
                          {
                              id = s.Name,
                              name = s.Name
                          }
              ).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetWorkProcessBy(string Factory, string Department)
        {

            if (Department != null && Department.Equals("*"))
                Department = null;

            if (Factory != null && Factory.Equals("*"))
                Factory = null;


            var dep = _repository.GetWorkProcessBy(Factory, Department);
            var result = (from s in dep
                          select new
                          {
                              id = s.Name,
                              name = s.Name
                          }
                          ).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getworkstationby(string Factory, string workprocess)
        {

            var dep = _repository.GetWorkstationBy(Factory,null, workprocess,null, true);
            var result = (from s in dep
                          select new
                          {
                              id = s.Id,
                              name = s.Name
                          }
                          ).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
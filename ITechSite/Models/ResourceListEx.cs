using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ITechSite.Models
{

    public class ResourceListFind
    {
        [DisplayName("Szukaj frazy")]
        public string Find_Word { get; set; }
        [DisplayName("Proces roboczy")]
        public string WorkProcess { get; set; }
        [DisplayName("Typ zasobu")]
        public string Find_ResourceType { get; set; }
        [DisplayName("Fabryka")]
        public string Factory { get; set; }
        [DisplayName("Projekt")]
        public string Department { get; set; }

        [DisplayName("Stanowiska")]
        public int? Workstation { get; set; }


        /// <summary>
        /// cz jest możliwość zmiany typu resource
        /// </summary>
        public bool Allow_ResourceType { get; set; }
        
        public string ReturnUrl { get; set; }

        public string FindAction { get; set; }

        public int? page { get; set; }



        public PagedList.IPagedList<Resource> Resources { get; set; }

        public IList<SelectListItem> AvailableFactory { get; set; }
        public IList<SelectListItem> AvailableDepartment { get; set; }
        public IList<SelectListItem> AvailableWorkPorcess { get; set; }
        public IList<SelectListItem> AvailableResourceType { get; set; }
        public IList<SelectListItem> AvailableWorkstation { get; set; }

        //public List<WorkProcess> WorkProcess { get; set; }
        //public List<ResourceType> ResourceType { get; set; }


        private static ResourceListFind GetOrDefault()
        {
            var rf = (ResourceListFind)HttpContext.Current.Session["ResourceListFind"];
            if (rf != null)
                return rf;
            return new ResourceListFind();
        }

        public void SetAsDefault()
        {
            HttpContext.Current.Session["ResourceListFind"] = this;
        }


        public static ResourceListFind From(ResourceListFind rf)
        {
            if (rf == null)
                rf = GetOrDefault();
            else
                if (rf.FindAction == null)
                    rf = GetOrDefault();

            return rf;
        }
      
        public ResourceListFind()
      {
          Allow_ResourceType=true;
      }


        public List<Resource> GetWorkstation(ITechEntities context)
        {
            FactoryRepository _repository = new FactoryRepository(context);
            if (string.IsNullOrEmpty(Find_ResourceType))
                Find_ResourceType = "Stanowisko";
            var Resources2 = _repository.GetResourcesBy(Factory, Department, WorkProcess, Find_ResourceType, Find_Word, true, false);
            return Resources2;
        }

       public ResourceListFind Fill(ITechEntities context)
      {
          FactoryRepository _repository = new FactoryRepository();

          AvailableResourceType = _repository.GetResourceTypeAll().ToSelectedList(m => new SelectListItem { Text = m.Type, Value = m.Type });
          AvailableFactory = _repository.GetFactoryAll().ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Name });
          AvailableDepartment = _repository.GetDepartmentByFactoryName(Factory).ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Name });
          AvailableWorkPorcess = _repository.GetWorkProcessBy(Factory, Department).ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Name });
          AvailableWorkstation = _repository.GetWorkstationBy(Factory, Department, WorkProcess, string.Empty, true).ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });


          if (string.IsNullOrEmpty(Find_ResourceType))
            Find_ResourceType = "Stanowisko";
          var Resources2 = _repository.GetResourcesBy(Factory, Department, WorkProcess, Find_ResourceType,Find_Word, Workstation, false);
          Resources = Resources2.ToPagedList(page ?? 1, 50);
          return this;
      }
    }
}
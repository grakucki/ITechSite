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

        //public List<WorkProcess> WorkProcess { get; set; }
        //public List<ResourceType> ResourceType { get; set; }


      public ResourceListFind()
      {
          Allow_ResourceType=true;
      }

       

      public void Fill(ITechEntities context)
      {
          IFactoryRepository _repository = new FactoryRepository();

          AvailableResourceType = _repository.GetResourceTypeAll().ToSelectedList(m => new SelectListItem { Text = m.Type, Value = m.Type });
          AvailableFactory = _repository.GetFactoryAll().ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Name });
          AvailableDepartment = _repository.GetDepartmentByFactoryName(Factory).ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Name });
          AvailableWorkPorcess = _repository.GetWorkProcessBy(Factory, Department).ToSelectedList(m => new SelectListItem { Text = m.Name, Value = m.Name });
          

          //var Resources2 = context.Resource
          //    .Where(i =>
          //        (i.Name.IndexOf(Find_Word) >= 0 || i.Description.IndexOf(Find_Word) >= 0 || Find_Word == null)
          //        && (Find_WorkProcess == null || Find_WorkProcess == "*" || i.WorkProcess == Find_WorkProcess)
          //        && (Find_ResourceType == null || Find_ResourceType == "*" || i.ResourceType.Type == Find_ResourceType)
          //     ).OrderBy(i => i.Name);
          var Resources2 = context.Resource.AsEnumerable();


          if (!Models.Repository.FilterExtansion.IsEmpty(Find_ResourceType))
                  Resources2 = Resources2.Where(m => m.ResourceType.Type == Find_ResourceType);

          if (!Models.Repository.FilterExtansion.IsEmpty(Factory))
                  Resources2 = Resources2.Where(m => m.Factory == Factory);

          //if (!Models.Repository.FilterExtansion.IsEmpty(Department))
          //    Resources2 = Resources2.Join(context.WorkProcess, c => c.WorkProcess, d => d.Name, (c, m) => new { c, m })
          //        .Where(m => m.m.Department.Name == Department).Select(m => m.c);

          if (!Models.Repository.FilterExtansion.IsEmpty(WorkProcess))
              Resources2 = Resources2.Where(m => m.WorkProcess == WorkProcess);


          if (!Models.Repository.FilterExtansion.IsEmpty(Find_Word))
                  Resources2= Resources2.Where(m=>m.Name.IndexOf(Find_Word) >= 0);


          Resources2 = Resources2.OrderBy(m => m.Name);
          Resources = Resources2.ToPagedList(page ?? 1, 10);
      }

        //public void Fill2(ITechEntities context)
        //{
        //    WorkProcess = new List<Models.WorkProcess>();
        //    WorkProcess.Add(new WorkProcess { Id = -1, Name = "*" });
        //    WorkProcess.AddRange(context.WorkProcess.OrderBy(m => m.Name));

        //    ResourceType = new List<Models.ResourceType>();
        //    //ResourceType.Add(new ResourceType { id = -1, Type = "*" });
        //    ResourceType.AddRange(context.ResourceType.OrderBy(m => m.Type));


        //    var Resources2 = context.Resource
        //        .Where(i =>
        //            (i.Name.IndexOf(Find_Word) >= 0 || i.Description.IndexOf(Find_Word) >= 0 || Find_Word == null)
        //            && (Find_WorkProcess == null || Find_WorkProcess == "*" || i.WorkProcess == Find_WorkProcess)
        //            && (Find_ResourceType == null || Find_ResourceType == "*" || i.ResourceType.Type == Find_ResourceType)
        //         ).OrderBy(i => i.Name);

        //    Resources = Resources2.ToPagedList(page ?? 1 , 10);
        //}

    }
}
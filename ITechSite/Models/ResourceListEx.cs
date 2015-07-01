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
        public string Find_WorkProcess { get; set; }
        [DisplayName("Typ zasobu")]
        public string Find_ResourceType { get; set; }

        public bool Allow_ResourceType { get; set; }

        
        public string ReturnUrl { get; set; }
        

        public int? page { get; set; }

        public PagedList.IPagedList<Resource> Resources { get; set; }
        public List<WorkProcess> WorkProcess { get; set; }
        public List<ResourceType> ResourceType { get; set; }

      public ResourceListFind()
      {
          Allow_ResourceType=true;
      }
       
        public void Fill(ITechEntities context)
        {
            WorkProcess = new List<Models.WorkProcess>();
            WorkProcess.Add(new WorkProcess { Id = -1, Name = "*" });
            WorkProcess.AddRange(context.WorkProcess.OrderBy(m => m.Name));

            ResourceType = new List<Models.ResourceType>();
            ResourceType.Add(new ResourceType { id = -1, Type = "*" });
            ResourceType.AddRange(context.ResourceType.OrderBy(m => m.Type));


            var Resources2 = context.Resource.Where(i => i.Enabled)
                .Where(i =>
                    (i.Name.IndexOf(Find_Word) >= 0 || i.Description.IndexOf(Find_Word) >= 0 || Find_Word == null)
                    && (Find_WorkProcess == null || Find_WorkProcess == "*" || i.WorkProcess == Find_WorkProcess)
                    && (Find_ResourceType == null || Find_ResourceType == "*" || i.ResourceType.Type == Find_ResourceType)
                 ).OrderBy(i => i.Name);

            Resources = Resources2.ToPagedList(page ?? 1 , 10);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITechSite.Models;

namespace ITechSite.Areas.Settings.Models
{
    public class FactoriesEditViewModel 
    {
        public FactoriesEditViewModel(ITechSite.Models.Factory factory)
        {
            Factory = factory;
        }
        public ITechSite.Models.Factory Factory { get; set; }
        public ICollection<ITechSite.Models.WorkProcess>  AvailableWorkProcess { get; set; }
        public ICollection<ITechSite.Models.Department> AvailableProject { get; set; }
    }
}
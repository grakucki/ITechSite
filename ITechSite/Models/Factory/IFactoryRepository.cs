using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite.Models
{
    public interface IFactoryRepository
    {
        IList<Factory> GetFactoryAll(bool AddEmpty = true);
        IList<Department> GetDepartmentAll(bool AddEmpty = true);
        IList<Department> GetDepartmentByFactoryName(string factoryName, bool AddEmpty = true);
        IList<WorkProcess> GetWorkProcessAll(bool AddEmpty = true);
        IList<WorkProcess> GetWorkProcessBy(string factoryName, string department, bool AddEmpty=true);
        IList<ResourceType> GetResourceTypeAll(bool AddEmpty = false);
        bool IsEmptyFiltr(string filtr);
    }
}
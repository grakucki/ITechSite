using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite.Models
{
    public class FactoryRepository : IFactoryRepository
    {
        private ITechEntities _dataContex;

        public FactoryRepository()
        {
            _dataContex = new ITechEntities();
        }

        public IList<Factory> GetFactoryAll(bool AddEmpty = true)
        {
            var query = _dataContex.Factory;
            var l = query.ToList<Factory>();
            if (AddEmpty)
                l.Insert(0, new Factory { Name = "*", Id = 0 });
            return l;

        }

        public bool IsEmptyFiltr(string filtr)
        {
            if (string.IsNullOrEmpty(filtr))
                return true;
            if (filtr=="*")
                return true;
            return false;

        }

        public IList<Department> GetDepartmentByFactoryName(string factoryName, bool AddEmpty = true)
        {
            if (IsEmptyFiltr(factoryName))
                return GetDepartmentAll(AddEmpty);

            
            var query = _dataContex.Department.Where(m => m.Factory.Any(f => f.Name.Contains(factoryName)));

            var l = query.ToList<Department>();
            if (AddEmpty)
                l.Insert(0, new Department { Name = "*", Id = 0 });
            return l;
        }


        public IList<Department> GetDepartmentAll(bool AddEmpty = true)
        {
            var query = _dataContex.Department;
            var l = query.ToList<Department>();
            if (AddEmpty)
                l.Insert(0, new Department { Name = "*", Id = 0 });
            return l;
        }


        public IList<WorkProcess> GetWorkProcessAll(bool AddEmpty = true)
        {
            var query = _dataContex.WorkProcess;
            var l = query.ToList<WorkProcess>();
            if (AddEmpty)
                l.Insert(0, new WorkProcess { Name = "*", Id = 0 });
            return l;
        }

        public IList<WorkProcess> GetWorkProcessBy(string factoryName, string department, bool AddEmpty=true)
        {
            var query = _dataContex.WorkProcess.AsQueryable();
            if (!IsEmptyFiltr(factoryName))
            {
                query= query.Where(m => m.Department.Factory.Any(n => n.Name == factoryName));
            }

            if (!IsEmptyFiltr(department))
            {
                query = query.Where(m => m.Department.Name == department);
            }
            var l = query.ToList<WorkProcess>();
            if (AddEmpty)
                l.Insert(0, new WorkProcess { Name = "*", Id = 0 });
            return l;
        }


        public IList<ResourceType> GetResourceTypeAll(bool AddEmpty = false)
        {
            var query = _dataContex.ResourceType.OrderBy(m => m.id).ToList();
            var l = query.ToList<ResourceType>();
            if (AddEmpty)
                l.Insert(0, new ResourceType {  Type = "*", id = 0 });
            return l;
        }
    }
}
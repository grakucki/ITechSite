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
            _dataContex = new ITechEntities(0);
        }

        public FactoryRepository(ITechEntities dataContex)
        {
            _dataContex = dataContex;
        }

        public IList<Factory> GetFactoryAll(bool AddEmpty = true)
        {
            var query = _dataContex.Factory;
            var l = query.ToList<Factory>();
            if (AddEmpty)
                l.Insert(0, new Factory { Name = "*", Id = 0 });
            return l;
        }

        public IList<Department> GetDepartmentByFactoryName(string factoryName, bool AddEmpty = true)
        {
            if (Repository.FilterExtansion.IsEmpty(factoryName,"*"))
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
            if (!Repository.FilterExtansion.IsEmpty(factoryName,"*"))
            {
                query= query.Where(m => m.Factory.Any(n=>n.Name == factoryName));
            }

            //if (!Repository.FilterExtansion.IsEmpty(department,"*"))
            //{
            //    query = query.Where(m => m.Department.Name == department);
            //}
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


        public List<Resource> GetWorkstationBy(string factoryName, string department, string WorkProcess, string Find_Word, bool AddEmpty = false)
        {
            var Resources2 = _dataContex.Resource.AsEnumerable();

             Resources2 = Resources2.Where(m => m.ResourceType.id == 1);

             if (!Models.Repository.FilterExtansion.IsEmpty(factoryName))
                 Resources2 = Resources2.Where(m => m.Factory == factoryName);

            //if (!Models.Repository.FilterExtansion.IsEmpty(Department))
            //    Resources2 = Resources2.Join(context.WorkProcess, c => c.WorkProcess, d => d.Name, (c, m) => new { c, m })
            //        .Where(m => m.m.Department.Name == Department).Select(m => m.c);

             if (!Models.Repository.FilterExtansion.IsEmpty(WorkProcess))
                Resources2 = Resources2.Where(m => m.WorkProcess == WorkProcess);


            if (!Models.Repository.FilterExtansion.IsEmpty(Find_Word))
                Resources2 = Resources2.Where(m => m.Name.IndexOf(Find_Word) >= 0);


            var l = Resources2.OrderBy(m=>m.Name).ToList();
            if (AddEmpty)
                l.Insert(0, new Resource {  Id=0, Name = "*" });
            return l;
        }


        /// <summary>
        ///  Jeśli poadamy workstation to dołączana jest lista modeli należąca do workstation
        /// </summary>
        /// <param name="factoryName"></param>
        /// <param name="department"></param>
        /// <param name="WorkProcess"></param>
        /// <param name="Find_ResourceType"></param>
        /// <param name="Find_Word"></param>
        /// <param name="Workstation"></param>
        /// <param name="AddEmpty"></param>
        /// <returns></returns>
        public List<Resource> GetResourcesBy(string factoryName, string department, string WorkProcess, string Find_ResourceType, string Find_Word, int? Workstation, bool AddEmpty = false)
        {
            var Resources2 = _dataContex.Resource.AsEnumerable();

            if (!Models.Repository.FilterExtansion.IsEmpty(Find_ResourceType))
                Resources2 = Resources2.Where(m => m.ResourceType.Type == Find_ResourceType);

            if (!Models.Repository.FilterExtansion.IsEmpty(factoryName))
                Resources2 = Resources2.Where(m => m.Factory == factoryName);

            if (!Models.Repository.FilterExtansion.IsEmpty(WorkProcess))
                Resources2 = Resources2.Where(m => m.WorkProcess == WorkProcess);

            if (!Models.Repository.FilterExtansion.IsEmpty(Workstation))
                Resources2 = Resources2.Where(m => m.Id == Workstation.Value);


            //if (!Models.Repository.FilterExtansion.IsEmpty(Department))
            //    Resources2 = Resources2.Join(context.WorkProcess, c => c.WorkProcess, d => d.Name, (c, m) => new { c, m })
            //        .Where(m => m.m.Department.Name == Department).Select(m => m.c);


            if (!Models.Repository.FilterExtansion.IsEmpty(Find_Word))
                Resources2 = Resources2.Where(m => m.Name.IndexOf(Find_Word) >= 0);


            var l = Resources2.OrderBy(m => m.Name).ToList(); 
            
            if (!Models.Repository.FilterExtansion.IsEmpty(Workstation))
            {

                // dodajemy modele
                var models = _dataContex.Resource.Where(m => m.Enabled == true && m.Type == 2 && m.ModelsWorkstationModel.Any(n => n.idW == Workstation.Value)).OrderBy(m=>m.Name).ToList();
                l.AddRange(models);

                // dodajemy wersje modeli

                //foreach (var item in models)
                //{
                //    var vm = _dataContex.Resource.Where(m => 
                //        m.Enabled == true
                //        && m.ResourceModelParent.Any(n=>n.Id==item.Id)
                //        ).OrderBy(m => m.Name).ToList();
                //    l.AddRange(vm);
                //}
            }


            
            if (AddEmpty)
                l.Insert(0, new Resource { Id = 0, Name = "*" });
            return l;
        }


        public List<Resource> GetResourcesBy(string factoryName, string department, string WorkProcess, string Find_ResourceType, string Find_Word, bool AddEmpty = false)
        {
            var Resources2 = _dataContex.Resource.AsEnumerable();

            if (!Models.Repository.FilterExtansion.IsEmpty(Find_ResourceType))
                Resources2 = Resources2.Where(m => m.ResourceType.Type == Find_ResourceType);


            if (!Models.Repository.FilterExtansion.IsEmpty(factoryName))
                Resources2 = Resources2.Where(m => m.Factory == factoryName);

            //if (!Models.Repository.FilterExtansion.IsEmpty(Department))
            //    Resources2 = Resources2.Join(context.WorkProcess, c => c.WorkProcess, d => d.Name, (c, m) => new { c, m })
            //        .Where(m => m.m.Department.Name == Department).Select(m => m.c);

            if (!Models.Repository.FilterExtansion.IsEmpty(WorkProcess))
                Resources2 = Resources2.Where(m => m.WorkProcess == WorkProcess);


            if (!Models.Repository.FilterExtansion.IsEmpty(Find_Word))
                Resources2 = Resources2.Where(m => m.Name.IndexOf(Find_Word) >= 0);


            var l = Resources2.OrderBy(m => m.Name).ToList();
            if (AddEmpty)
                l.Insert(0, new Resource { Id = 0, Name = "*" });
            return l;
        }


    }
}
using LinkDev.IKEA.DAL.Constract.Repositries;
using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistence.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {

        private readonly ApplicationDbContext _DbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (!withTracking)
            {
                return _DbContext.departments.AsNoTracking();
            }
            return _DbContext.departments;
        }

        public Department? GetById(int id)
        {
             var department = _DbContext.departments.Find(id);
            return department;
        }

        public void Add(Department entity)
         => _DbContext.departments.Add(entity);
      
      

        public void Update(Department entity)
          => _DbContext.departments.Update(entity);
             
       

        public void Delete(int id)
        {
             var department = _DbContext.departments.Find(id);
            if (department is { })
            {
                _DbContext.departments.Remove(department);
          
            }
            
        }

      

    }
}

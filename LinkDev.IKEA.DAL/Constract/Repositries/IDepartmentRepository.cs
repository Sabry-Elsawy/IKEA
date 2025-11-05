using LinkDev.IKEA.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Constract.Repositries
{
    public interface IDepartmentRepository
    {

        IEnumerable<Department> GetAll(bool withTracking = false);

        Department GetById(int id );

        void Add(Department entity);

        void Update(Department entity);

        void Delete( int id);
    }
}

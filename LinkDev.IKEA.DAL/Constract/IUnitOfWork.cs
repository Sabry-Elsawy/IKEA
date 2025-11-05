using LinkDev.IKEA.DAL.Constract.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Constract
{
    public interface IUnitOfWork
    {

        public IDepartmentRepository DepartmentRepository { get; set; }

        int Complete();

        void Dispose();
    }
}

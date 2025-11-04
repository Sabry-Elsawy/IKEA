using LinkDev.IKEA.DAL.Constract;
using LinkDev.IKEA.DAL.Constract.Repositries;
using LinkDev.IKEA.DAL.Persistence.Data;
using LinkDev.IKEA.DAL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _DbContext;

        public IDepartmentRepository? DepartmentRepository { get; set; }

       public UnitOfWork(ApplicationDbContext dbContext) 
        {
            DepartmentRepository = new DepartmentRepository(dbContext);
            _DbContext = dbContext;
        }

        public void Complete()
        {
            _DbContext.SaveChanges();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }
    }
}

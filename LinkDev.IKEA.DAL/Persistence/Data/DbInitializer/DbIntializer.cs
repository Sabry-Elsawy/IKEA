using LinkDev.IKEA.DAL.Constract;
using LinkDev.IKEA.DAL.Entities.Department;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistence.Data.DbInitializer
{
    public class DbIntializer : IDbIntializer
    {
        private readonly ApplicationDbContext _DbContext;

        public DbIntializer(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public void Initialize()
        {
            if (_DbContext.Database.GetPendingMigrations().Any())
            {
                _DbContext.Database.Migrate();
            }
        }

        public void seed()
        {
            if (!_DbContext.departments.Any())
            {
                var departmentsDate = File.ReadAllText("../LinkDev.IKEA.DAL/Persistence/Data/Seeds/departments.json");
                var departments = JsonSerializer.Deserialize<List<Department>>(departmentsDate);

                if (departments?.Count > 0)
                {
                    _DbContext.departments.AddRange(departments);
                    _DbContext.SaveChanges();
                }
            }


        }

     
    }
}

using LinkDev.IKEA.DAL.Persistence.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.IKEA.DAL.Entities.Department;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.IKEA.DAL.Persistence.Data.Configurations.Departments
{
    internal class DepartmentConfigurations : BaseAuditableEntityConfigurations<int, Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("NVARCHAR(100)");
            builder.Property(D => D.Description).HasColumnType("NVARCHAR(300)");
            builder.Property(D => D.Code).HasColumnType("NVARCHAR(10)");
        }
    }
}

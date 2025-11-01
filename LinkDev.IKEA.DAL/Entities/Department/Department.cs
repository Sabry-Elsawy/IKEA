using LinkDev.IKEA.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Entities.Department
{
    public class Department : BaseAuditableEntity<int>
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public string? Description { get; set; }
 
        public DateOnly CreationDate { get; set; }
    }
}

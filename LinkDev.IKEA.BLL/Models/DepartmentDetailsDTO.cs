using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models
{
    public record DepartmentDetailsDTO(int ID, string Name, string Code, DateOnly CreationDate, string? Description, string CreatedBy, DateTime CreatedOn, string LastModifiedBy, DateTime LastModifiedOn);
}

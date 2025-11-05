using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models
{
    public record UpdateDepartmentDTO(int ID, string Name, string Code, DateOnly CreationDate, string? Description);
}

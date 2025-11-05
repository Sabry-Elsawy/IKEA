using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models
{
    public record CreateDepartmentDTO(string Name, string Code, string? Description, DateOnly CreationDate);
}

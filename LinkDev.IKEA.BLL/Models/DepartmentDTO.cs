using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models
{
    public record DepartmentDTO(int Id, string Name, string Code, DateOnly CreationDate);
}

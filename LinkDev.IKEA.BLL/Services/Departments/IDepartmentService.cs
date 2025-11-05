using LinkDev.IKEA.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetDepartments();

        DepartmentDetailsDTO? GetDepartmentById(int id);

        int CreateDepartment(CreateDepartmentDTO department);

        int UpdateDepartment(UpdateDepartmentDTO department);

        bool DeleteDepartment(int id);
    }
}

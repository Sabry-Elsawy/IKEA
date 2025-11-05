using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetDepartments();
            var departmentViewModels = departments.Select(Deartment => new DepartmentViewModel()
            {
                Id = Deartment.Id,
                Name = Deartment.Name,
                Code = Deartment.Code,
                CreationDate = Deartment.CreationDate
            });
            return View(departmentViewModels);
        }
    }
}

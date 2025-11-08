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

		[HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            var DepartmentDetailsViewModel = new DepartmentDetailsViewModel()
			{
				Id = department.ID,
				Name = department.Name,
				Code = department.Code,
				Description = department.Description,
				CreationDate = department.CreationDate,
				CreatedBy = department.CreatedBy,
				CreatedOn = department.CreatedOn,
				LastModifiedBy = department.LastModifiedBy,
				LastModifiedOn = department.LastModifiedOn
			};

			return View(DepartmentDetailsViewModel);
        }
	}
}

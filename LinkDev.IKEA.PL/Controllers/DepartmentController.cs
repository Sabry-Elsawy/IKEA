using LinkDev.IKEA.BLL.Models;
using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentViewModel model)
        {
            var message = "Department created successfully.";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var departmentToCreate = new CreateDepartmentDTO(model.Name, model.Code, model.Description, model.CreationDate) { };
                var CreatedDepartment = _departmentService.CreateDepartment(departmentToCreate) > 0;
               
                if (!CreatedDepartment)
                {
                    message = "Failed to create Department.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,ex.StackTrace!.ToString());
                message = "An error occurred while creating the Department.";
            }
            TempData["Message"] =  message;

            return RedirectToAction(nameof(Index));
        }
}
}

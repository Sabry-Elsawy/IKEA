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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
               
                var departmentToCreate = new CreateDepartmentDTO(model.Name, model.Code, model.Description, model.CreationDate) { };
                var CreatedDepartment = _departmentService.CreateDepartment(departmentToCreate) > 0;

                if (!CreatedDepartment)
                {
                    message = "Failed to create Department.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                message = "An error occurred while creating the Department.";
            }
            TempData["Message"] = message;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
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
            var updateDepartmentViewModel = new UpdateDepartmentViewModel()
            {
                Id = department.ID,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate
            };
            TempData["Id"] = id;
            return View(updateDepartmentViewModel);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdateDepartmentViewModel model)
        {
            var message = "Department updated successfully.";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if ((int?)TempData["Id"] != id)
            {
                return BadRequest();
            }
            try
            {
           
                var departmentToUpdate = new UpdateDepartmentDTO(id, model.Name, model.Code,  model.CreationDate, model.Description) { };
                var updatedDepartment = _departmentService.UpdateDepartment(departmentToUpdate) > 0;

                if (!updatedDepartment)
                {
                    message = "Failed to update Department.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                message = "An error occurred while updating the Department.";
            }
            TempData["Message"] = message;

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var message = "Department deleted successfully.";
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var deletedDepartment = _departmentService.DeleteDepartment(id.Value) ;

                if (!deletedDepartment)
                {
                    message = "Failed to delete Department.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                message = "An error occurred while deleting the Department.";
            }
            TempData["Message"] = message;

            return RedirectToAction(nameof(Index));
        }
        }
}

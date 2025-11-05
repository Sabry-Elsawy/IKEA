using LinkDev.IKEA.BLL.Models;
using LinkDev.IKEA.DAL.Constract;
using LinkDev.IKEA.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    internal class DepartmentServices : IDepartmentService
    {

        private readonly IUnitOfWork _unitOfWork;
        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
             var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null)
                return null;

            return new DepartmentDetailsDTO(
                department.Id,
                department.Name,
                department.Code,
                department.CreationDate,
                department.Description,
                department.CreatedBy,
                department.CreatedOn,
                department.LastModifiedBy,
                department.LastModifiedOn
                );
        }
        public IEnumerable<DepartmentDTO> GetDepartments()
        {
             var departments = _unitOfWork.DepartmentRepository.GetAll();
            foreach ( var department in departments ) {
                yield return new DepartmentDTO(
                       department.Id,
                       department.Name,
                       department.Code,
                       department.CreationDate
                       );
            }
        }
        public int CreateDepartment(CreateDepartmentDTO department)
        {
            var departmentToCreate = new Department()
            {
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description,
                CreatedBy =  "",
                LastModifiedBy = "",
              
            };
            _unitOfWork.DepartmentRepository.Add(departmentToCreate);
            return _unitOfWork.Complete();
        }

        public bool DeleteDepartment(int id)
        {
             _unitOfWork.DepartmentRepository.Delete(id);
            var deleted = _unitOfWork.Complete()>0;
            return deleted;
        }



        public int UpdateDepartment(UpdateDepartmentDTO department)
        {
             var departmentToUpdate =  new Department()
             {
                 Id = department.ID,
                 Name = department.Name,
                 Code = department.Code,
                 CreationDate = department.CreationDate,
                 Description = department.Description,
                 CreatedBy = "",
                 LastModifiedBy = "",

             };
            _unitOfWork.DepartmentRepository.Update(departmentToUpdate);
            return _unitOfWork.Complete();
        }
    }
}

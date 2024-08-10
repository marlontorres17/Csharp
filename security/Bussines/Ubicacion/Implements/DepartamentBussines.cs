using Bussines.Ubicacion.Interface;
using Data.DTO;
using Data.Interface;
using Entity.DTO;
using Entity.Model.Ubicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Ubicacion.Implements
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            return _departmentRepository.GetAll().Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                CountryId = d.CountryId
            });
        }

        public DepartmentDto GetById(int id)
        {
            var department = _departmentRepository.GetById(id);
            return new DepartmentDto { DepartmentId = department.DepartmentId, Name = department.Name, CountryId = department.CountryId };
        }

        public void Add(DepartmentDto department)
        {
            _departmentRepository.Add(new Department { Name = department.Name, CountryId = department.CountryId });
        }

        public void Update(DepartmentDto department)
        {
            var existingDepartment = _departmentRepository.GetById(department.DepartmentId);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                existingDepartment.CountryId = department.CountryId;
                _departmentRepository.Update(existingDepartment);
            }
        }

        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
        }
    }
}

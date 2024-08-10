using Data.DTO;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IDepartmentController
    {
        IEnumerable<DepartmentDto> Get();
        DepartmentDto Get(int id);
        void Add(DepartmentDto departmentDto);
        void Update(int id, DepartmentDto departmentDto);
        void Delete(int id);
    }
}

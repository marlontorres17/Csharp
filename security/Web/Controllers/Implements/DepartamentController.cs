using Bussines.Ubicacion.Interface;
using Data.DTO;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase, IDepartmentController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IEnumerable<DepartmentDto> Get()
        {
            return _departmentService.GetAll();
        }

        [HttpGet("{id}")]
        public DepartmentDto Get(int id)
        {
            return _departmentService.GetById(id);
        }

        [HttpPost]
        public void Add(DepartmentDto departmentDto)
        {
            _departmentService.Add(departmentDto);
        }

        [HttpPut("{id}")]
        public void Update(int id, DepartmentDto departmentDto)
        {
            _departmentService.Update(departmentDto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _departmentService.Delete(id);
        }
    }
}

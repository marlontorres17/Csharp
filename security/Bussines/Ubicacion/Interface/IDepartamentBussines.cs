using Data.DTO;
using Entity.DTO;
using Entity.Model.Ubicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Ubicacion.Interface
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAll();
        DepartmentDto GetById(int id);
        void Add(DepartmentDto department);
        void Update(DepartmentDto department);
        void Delete(int id);
    }
}

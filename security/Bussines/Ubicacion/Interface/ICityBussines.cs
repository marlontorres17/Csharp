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
    public interface ICityService
    {
        IEnumerable<CityDto> GetAll();
        CityDto GetById(int id);
        void Add(CityDto city);
        void Update(CityDto city);
        void Delete(int id);
    }
}

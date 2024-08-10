using Data.DTO;
using Entity.DTO;
using Entity.Model.Ubicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        City GetById(int id);
        void Add(City city);
        void Update(City city);
        void Delete(int id);
    }
}

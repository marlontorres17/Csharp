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
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetAll();
        CountryDto GetById(int id);
        void Add(CountryDto country);
        void Update(CountryDto country);
        void Delete(int id);
    }
}

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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<CityDto> GetAll()
        {
            return _cityRepository.GetAll().Select(c => new CityDto
            {
                CityId = c.CityId,
                Name = c.Name,
                DepartmentId = c.DepartmentId
            });
        }

        public CityDto GetById(int id)
        {
            var city = _cityRepository.GetById(id);
            return new CityDto { CityId = city.CityId, Name = city.Name, DepartmentId = city.DepartmentId };
        }

        public void Add(CityDto city)
        {
            _cityRepository.Add(new City { Name = city.Name, DepartmentId = city.DepartmentId });
        }

        public void Update(CityDto city)
        {
            var existingCity = _cityRepository.GetById(city.CityId);
            if (existingCity != null)
            {
                existingCity.Name = city.Name;
                existingCity.DepartmentId = city.DepartmentId;
                _cityRepository.Update(existingCity);
            }
        }

        public void Delete(int id)
        {
            _cityRepository.Delete(id);
        }
    }
}

using Bussines.Ubicacion.Interface;
using Data.DTO;
using Data.Implements;
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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IEnumerable<CountryDto> GetAll()
        {
            return _countryRepository.GetAll().Select(c => new CountryDto
            {
                CountryId = c.CountryId,
                Name = c.Name
            });
        }

        public CountryDto GetById(int id)
        {
            var country = _countryRepository.GetById(id);
            return new CountryDto { CountryId = country.CountryId, Name = country.Name };
        }

        public void Add(CountryDto country)
        {
            _countryRepository.Add(new Country { Name = country.Name });
        }

        public void Update(CountryDto country)
        {
            var existingCountry = _countryRepository.GetById(country.CountryId);
            if (existingCountry != null)
            {
                existingCountry.Name = country.Name;
                _countryRepository.Update(existingCountry);
            }
        }

        public void Delete(int id)
        {
            _countryRepository.Delete(id);
        }
    }

}

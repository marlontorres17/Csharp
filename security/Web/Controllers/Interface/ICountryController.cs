using Data.DTO;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICountryController
    {
        IEnumerable<CountryDto> Get();
        CountryDto Get(int id);
        void Add(CountryDto countryDto);
        void Update(int id, CountryDto countryDto);
        void Delete(int id);
    }
}

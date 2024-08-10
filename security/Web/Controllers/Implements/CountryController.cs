using Bunnisses.Security.Interface;
using Bussines.Ubicacion.Implements;
using Bussines.Ubicacion.Interface;
using Data.DTO;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;
using WebC.Controllers.Interfaces;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase, ICountryController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IEnumerable<CountryDto> Get()
        {
            return _countryService.GetAll();
        }

        [HttpGet("{id}")]
        public CountryDto Get(int id)
        {
            return _countryService.GetById(id);
        }

        [HttpPost]
        public void Add(CountryDto countryDto)
        {
            _countryService.Add(countryDto);
        }

        [HttpPut("{id}")]
        public void Update(int id, CountryDto countryDto)
        {
            _countryService.Update(countryDto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _countryService.Delete(id);
        }
    }
}

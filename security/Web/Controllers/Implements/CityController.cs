using Bussines.Ubicacion.Interface;
using Data.DTO;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase, ICityController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IEnumerable<CityDto> Get()
        {
            return _cityService.GetAll();
        }

        [HttpGet("{id}")]
        public CityDto Get(int id)
        {
            return _cityService.GetById(id);
        }

        [HttpPost]
        public void Add(CityDto cityDto)
        {
            _cityService.Add(cityDto);
        }

        [HttpPut("{id}")]
        public void Update(int id, CityDto cityDto)
        {
            _cityService.Update(cityDto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cityService.Delete(id);
        }
    }
}

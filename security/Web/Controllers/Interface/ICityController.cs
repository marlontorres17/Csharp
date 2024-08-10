using Data.DTO;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICityController
    {
        IEnumerable<CityDto> Get();
        CityDto Get(int id);
        void Add(CityDto cityDto);
        void Update(int id, CityDto cityDto);
        void Delete(int id);
    }
}

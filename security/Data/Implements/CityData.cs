using Data.DTO;
using Data.Interface;
using Entity.DTO;
using Entity.Model.Contexts;
using Entity.Model.Ubicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContexts _context;

        public CityRepository(ApplicationDbContexts context)
        {
            _context = context;
        }

        public IEnumerable<City> GetAll() => _context.city.ToList();

        public City GetById(int id) => _context.city.Find(id);

        public void Add(City city)
        {
            _context.city.Add(city);
            _context.SaveChanges();
        }

        public void Update(City city)
        {
            _context.city.Update(city);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var city = GetById(id);
            if (city != null)
            {
                _context.city.Remove(city);
                _context.SaveChanges();
            }
        }
    }

}

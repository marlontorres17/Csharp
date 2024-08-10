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
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContexts _context;

        public CountryRepository(ApplicationDbContexts context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAll() => _context.country.ToList();

        public Country GetById(int id) => _context.country.Find(id);

        public void Add(Country country)
        {
            _context.country.Add(country);
            _context.SaveChanges();
        }

        public void Update(Country country)
        {
            _context.country.Update(country);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var country = GetById(id);
            if (country != null)
            {
                _context.country.Remove(country);
                _context.SaveChanges();
            }
        }
    }
}

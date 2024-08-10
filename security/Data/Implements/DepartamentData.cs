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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContexts _context;

        public DepartmentRepository(ApplicationDbContexts context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll() => _context.department.ToList();

        public Department GetById(int id) => _context.department.Find(id);

        public void Add(Department department)
        {
            _context.department.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.department.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                _context.department.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}

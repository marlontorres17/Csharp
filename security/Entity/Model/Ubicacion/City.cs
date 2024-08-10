using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Ubicacion
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}

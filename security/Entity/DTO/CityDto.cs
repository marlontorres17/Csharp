﻿using Entity.Model.Ubicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}

﻿using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ViewDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string descripcion { get; set; }

        public string ruta { get; set; }

        public int ModuleId { get; set; }
        public Module module { get; set; }
        public Boolean State { get; set; }
    }
}

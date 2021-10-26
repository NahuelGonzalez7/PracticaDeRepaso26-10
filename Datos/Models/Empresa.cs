﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Empresa
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }

        public Empresa(string nombre, string cuit)
        {
            Nombre = nombre;
            Cuit = cuit;
        }
    }
}

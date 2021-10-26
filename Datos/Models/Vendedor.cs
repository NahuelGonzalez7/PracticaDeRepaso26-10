using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Vendedor : Persona
    {
        public decimal Comision { get; set; }

        public Vendedor(string nombre,string apellido,string dni, decimal comision) : base(nombre, apellido, dni)
        {
            Comision = comision;
        }

        public Vendedor()
        {
        }
    }
}

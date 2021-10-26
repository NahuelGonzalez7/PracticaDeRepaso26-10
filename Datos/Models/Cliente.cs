using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Cliente : Persona
    {
        public Cliente(string nombre, string apellido, string dni) : base(nombre, apellido, dni){}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos.AdmServer
{
    internal static class AdminBD
    {
        internal static SqlConnection conectarBase()
        {
            string cadena = Datos.Properties.Settings.Default.KeyDbVentas;
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();

            return conexion;
        }
    }
}

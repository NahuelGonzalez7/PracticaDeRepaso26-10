using Datos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos.AdmServer;

namespace Datos.AdmModels
{
    public static class AdmVendedor
    {
        public static List<Vendedor> Listar()
        {
            string consultaSQL = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor";

            SqlCommand command = new SqlCommand(consultaSQL, AdminBD.conectarBase());

            SqlDataReader reader;

            reader = command.ExecuteReader();

            List<Vendedor> listaVendedores = new List<Vendedor>();

            while (reader.Read())
            {
                listaVendedores.Add(
                    new Vendedor()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        DNI = reader["DNI"].ToString(),
                        Comision = Convert.ToDecimal(reader["Comision"])
                    }
                    );
            }

            AdminBD.conectarBase().Close();
            reader.Close();

            return listaVendedores;

            //ToDo Retorna una lista de vendedor, usar DataReader.

        }

        public static DataTable ListarComisiones()
        {
            string consultaSQL = " SELECT DISTINCT Comision FROM dbo.Vendedor ";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminBD.conectarBase());

            DataSet ds = new DataSet();

            adapter.Fill(ds,"vendedor");

            return ds.Tables["vendedor"];

        }

        public static DataTable TraerPorId(int id)
        {
            string consultaSQL = "SELECT Id ,Nombre ,Apellido ,DNI ,Comision FROM dbo.Vendedor WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminBD.conectarBase());

            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Id");

            return ds.Tables["Id"];

            //ToDo Retorna un DataTable
        }

        public static DataTable TraerVendedores(decimal comision)
        {
            string consultaSQL = "SELECT Id ,Nombre ,Apellido ,DNI ,Comision FROM dbo.Vendedor WHERE Comision = @Comision";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminBD.conectarBase());

            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Int).Value = comision;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Comision");

            return ds.Tables["Comision"];

            //ToDo traer vendedor por comision, devuelve la lista de vendedores por esa comision.
        }

        public static int Insertar(Vendedor vendedor)
        {
            string insertSQL = "INSERT dbo.vendedor (Nombre,Apellido,DNI,Comision) VALUES(@Nombre, @Apellido, @DNI, @Comision)";

            SqlCommand command = new SqlCommand(insertSQL, AdminBD.conectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            command.Parameters.Add("@DNI", SqlDbType.VarChar, 50).Value = vendedor.DNI;
            command.Parameters.Add("@Comision", SqlDbType.VarChar, 50).Value = vendedor.Comision;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminBD.conectarBase().Close();

            return filasAfectadas;

            //ToDo insertar Vendedor, retorna filas afectadas.
        }

        public static int Modificar(Vendedor vendedor)
        {
            string consultaSQL = "UPDATE dbo.Vendedor SET Nombre=@Nombre,Apellido=@Apellido,DNI=@DNI,Comision=@Comision WHERE Id=@Id ";

            SqlCommand command = new SqlCommand(consultaSQL, AdminBD.conectarBase());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = vendedor.ID;
            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            command.Parameters.Add("@DNI", SqlDbType.VarChar, 50).Value = vendedor.DNI;
            command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminBD.conectarBase().Close();

            return filasAfectadas;

            //ToDo modificar vendedor, retorna filas afectadas.
        }

        public static int Eliminar(int id)
        {
            string consultaSQL = "DELETE FROM dbo.Vendedor WHERE Id=@Id";

            SqlCommand command = new SqlCommand(consultaSQL, AdminBD.conectarBase());

            command.Parameters.Add("@Id",SqlDbType.Int).Value = id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminBD.conectarBase().Close();

            return filasAfectadas;

            //ToDo eliminar vendedor, devuelve filas afectadas.
        }
    }
}

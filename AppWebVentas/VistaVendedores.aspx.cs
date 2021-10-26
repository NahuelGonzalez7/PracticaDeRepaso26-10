using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos.Models;
using Datos.AdmModels;
using System.Data;

namespace AppWebVentas
{
    public partial class VistaVendedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarDatos();
            LlenarDropComisiones(); //NO OLVIDARME DE LLAMAR AL DROP EN EL LOAD!!!!!!!!!!!!
        }

        #region Mostrar Datos
        private void mostrarDatos()
        {
                gridVendedores.DataSource = AdmVendedor.Listar();
                gridVendedores.DataBind();         
        }
        #endregion

        #region Botones

        //LISTAR TODOS
        protected void btnListar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        //INSERTAR VENDEDOR
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Comision = Convert.ToDecimal(txtComision.Text)
            };

            int filasAfectadas = AdmVendedor.Insertar(vendedor);

            if(filasAfectadas > 0)
            {
                mostrarDatos();
            }
        }

        // ELIMINAR VENDEDOR
        protected void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            int idVendedor = Convert.ToInt32(txtID.Text);

            int filasAfectadas = AdmVendedor.Eliminar(idVendedor);

            if (filasAfectadas > 0)
            {
                mostrarDatos();
            }
        }

        // MODIFICAR VENDEDOR
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor()
            {
                ID = Convert.ToInt32(txtID.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Comision = Convert.ToDecimal(txtComision.Text)
            };

            int filasAfectadas = AdmVendedor.Modificar(vendedor);

            if(filasAfectadas > 0)
            {
                mostrarDatos();
            }
        }

        #endregion

        #region Llenar DROP y Traer por caracteristicas
        private void LlenarDropComisiones()
        {
            DataTable dt = AdmVendedor.ListarComisiones();
            ddlVendedorComision.Items.Add("Traer Comisiones");
            foreach (DataRow item in dt.Rows)
            {
                ddlVendedorComision.Items.Add(item["Comision"].ToString());
            }   
        }

        protected void btnTraerPorID_Click(object sender, EventArgs e)
        {
            int idVendedor = Convert.ToInt32(txtTraerPorID.Text);

            gridVendedores.DataSource = AdmVendedor.TraerPorId(idVendedor);
            gridVendedores.DataBind();
        }

        protected void ddlVendedorComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = ddlVendedorComision.SelectedValue;
            if (item == "Traer Comisiones")
            {
                mostrarDatos();
            }
            else
            {
                decimal comision = Convert.ToDecimal(ddlVendedorComision.SelectedValue);
                gridVendedores.DataSource = AdmVendedor.TraerVendedores(comision);
                gridVendedores.DataBind();
            }
        }
        #endregion
    }
}
using Datos.Admin;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTransportes
{
    public partial class WebTransportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarAutos();
                llenarCombo();
            }

        }
        private void MostrarAutos()
        {
            gridAuto.DataSource = AdminAuto.Listar();
            gridAuto.DataBind();
        }
        private void llenarCombo()
        {
            DataTable Marca = AdminAuto.ListarMarcas();
            ddlMarca.DataSource = Marca;
            ddlMarca.DataValueField = Marca.Columns["Marca"].ToString();
            ddlMarca.DataTextField = Marca.Columns["Marca"].ToString();
            DataTable BuscarMarca = AdminAuto.ListarMarcas();
            ddlBuscar.DataSource = BuscarMarca;
            ddlBuscar.DataValueField = BuscarMarca.Columns["Marca"].ToString();
            ddlBuscar.DataTextField = BuscarMarca.Columns["Marca"].ToString();
            DataRow fila = BuscarMarca.NewRow();
            fila["Marca"] = 0;
            fila["Marca"] = "[TODAS]";
            BuscarMarca.Rows.InsertAt(fila, 0);
            ddlMarca.DataBind();
            ddlBuscar.DataBind();
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Marca = Convert.ToString(ddlMarca.SelectedValue),
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text)
            };
            int filasAfectadas = AdminAuto.Insertar(auto);
            if (filasAfectadas > 0)
            {
                MostrarAutos();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Id = Convert.ToInt32(txtId.Text),
                Marca = Convert.ToString(ddlMarca.SelectedValue),
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text)
            };
            int filasAfectadas = AdminAuto.Modificar(auto);
            if (filasAfectadas > 0)
            {
                MostrarAutos();
            }
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = AdminAuto.Eliminar(id);
            if (filasAfectadas > 0)
            {
                MostrarAutos();
            }
        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = Convert.ToString(ddlBuscar.SelectedValue);
            if (marca == "[TODAS]")
            {
                MostrarAutos();
            }
            else
            {
                gridAuto.DataSource = AdminAuto.Listar(marca);
                gridAuto.DataBind();
            }
        }
    }
}
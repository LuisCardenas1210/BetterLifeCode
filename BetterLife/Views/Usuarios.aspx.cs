using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BetterLife.Models;

namespace BetterLife
{
	public partial class Usuarios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                CargarUsuario();
            }
        }
        private void CargarUsuario()
        {        
            using (var db = new BetterLifeContext())
            {
                var usuario = db.Usuario.ToList();
                gvUsuarios.DataSource = usuario;
                gvUsuarios.DataBind();
            }
        }
        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsuarios.Rows[index];
                string idUsuario = gvUsuarios.DataKeys[index].Value.ToString();

                // Redirigir a CrearRutina con el ID en la URL  
                Response.Redirect("CrearRutina.aspx?id=" + idUsuario);
            }
        }
    }
}
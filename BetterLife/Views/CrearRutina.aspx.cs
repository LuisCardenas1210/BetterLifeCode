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
	public partial class CrearRutina : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				CargarUsuario();
			}
		}

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string idUsuarioQS = Request.QueryString["id"];
                if (string.IsNullOrEmpty(idUsuarioQS))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('ID de usuario no encontrado en la URL');", true);
                    return;
                }

                int idUsuario = Convert.ToInt32(idUsuarioQS);
                string rutinaTexto = txtRutina.Text;

                using (var context = new BetterLifeContext())
                {
                    var rutina = new Rutinas(); 
                    rutina.Rutina = rutinaTexto;
                    rutina.id_Usuario = idUsuario;
                    rutina.id_Profesional = null;

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Rutina preparada: {rutinaTexto}, Usuario: {idUsuario}');", true);

                    context.Rutinas.Add(rutina);
                    context.SaveChanges();
                }

                Response.Redirect("Usuarios.aspx");
            }
            catch (Exception ex)
            {
                string fullError = ex.Message;
                if (ex.InnerException != null)
                    fullError += " | Inner: " + ex.InnerException.Message;
                if (ex.InnerException?.InnerException != null)
                    fullError += " | Inner-Inner: " + ex.InnerException.InnerException.Message;

                Response.Write("<pre>" + Server.HtmlEncode(fullError) + "</pre>");
                Response.End();
            }
        }
        private void CargarUsuario()
        {
            string idUsuario = Request.QueryString["id"];
            if (string.IsNullOrEmpty(idUsuario)) return;

            int id = int.Parse(idUsuario); 

            using (var db = new BetterLifeContext())
            {
                var usuario = db.Usuario.FirstOrDefault(u => u.id_Usuario == id);

                if (usuario != null)
                {
                    txtCliente.Text = usuario.Nombre_Usuario + " " + usuario.Apellidos_Usuario;
                    txtEdad.Text = usuario.Edad_Usuario.ToString();
                    txtPeso.Text = usuario.Peso_Usuario.ToString();
                    txtEstatura.Text = usuario.Estatura;
                    txtBrazoR.Text = usuario.BrazoRelajado;
                    txtBrazoC.Text = usuario.BrazoContraido;
                    txtCintura.Text = usuario.Cintura;
                    txtPierna.Text = usuario.Pierna;
                }
            }
        }

    }
}
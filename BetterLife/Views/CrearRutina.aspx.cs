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

                txtCliente.ReadOnly = true;
                txtEdad.ReadOnly = true;
                txtPeso.ReadOnly = true;
                txtEstatura.ReadOnly = true;
                txtBrazoR.ReadOnly = true;
                txtBrazoC.ReadOnly = true;
                txtCintura.ReadOnly = true;
                txtPierna.ReadOnly = true;
            }
		}

        protected void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.ID == "btnAgregar")
            {
                if (!Page.IsValid)
                    return;

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

                        //ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Rutina preparada: {rutinaTexto}, Usuario: {idUsuario}');", true);

                        context.Rutinas.Add(rutina);
                        context.SaveChanges();
                    }

                    lblMensaje.Text = "Rutina ingresada";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    //Response.Redirect("Usuarios.aspx");
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
            else if (btn.ID == "btnRegresar")
            {
                Response.Redirect("Usuarios.aspx");
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
                    this.txtCliente.Text = usuario.Nombre_Usuario + " " + usuario.Apellidos_Usuario;
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
        protected void cvRutina_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string value = args.Value?.Trim();
            args.IsValid = !string.IsNullOrEmpty(value) && value.Length >= 35 && value.Length <= 4000;
        }

    }
}
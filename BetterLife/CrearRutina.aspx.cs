using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string idUsuario = Request.QueryString["id"];
            if (string.IsNullOrEmpty(idUsuario))
            {
                return;
            }

            string rutinaTexto = txtRutina.Text;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBLDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Rutinas (Rutina, id_Usuario) VALUES (@rutina, @idUsuario)", conn);
                cmd.Parameters.AddWithValue("@rutina", rutinaTexto);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.ExecuteNonQuery();
            }

            // Mostrar confirmación o redirigir
            Response.Write("<script>alert('Rutina agregada correctamente');</script>");
        }


        private void CargarUsuario()
		{
            string idUsuario = Request.QueryString["id"];
            if (string.IsNullOrEmpty(idUsuario)) return;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBLDB"].ConnectionString;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("select u.id_Usuario, u.Nombre_Usuario, u.Apellidos_Usuario, u.Edad_Usuario, u.Genero_Usuario, " +
                    "uc.Estatura, uc.Peso_Usuario, uc.BrazoRelajado, uc.BrazoContraido, uc.Cintura, uc.Pierna " +
                    "from Usuario u join Usuario_Complemento uc on u.id_Usuario = uc.id_Usuario " +
                    "where u.id_Usuario=@id;", conn);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtCliente.Text = reader["Nombre_Usuario"].ToString() + " " + reader["Apellidos_Usuario"].ToString();
                    txtEdad.Text = reader["Edad_Usuario"].ToString();
                    txtPeso.Text = reader["Peso_Usuario"].ToString();
                    txtEstatura.Text = reader["Estatura"].ToString();
                    txtBrazoR.Text = reader["BrazoRelajado"].ToString();
                    txtBrazoC.Text = reader["BrazoContraido"].ToString();
                    txtCintura.Text = reader["Cintura"].ToString();
                    txtPierna.Text = reader["Pierna"].ToString();
                }

				reader.Close();
            }
		}
	}
}
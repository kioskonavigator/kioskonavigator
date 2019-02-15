using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kioskotem.wcfoperadora;

using System.Net.Mail;
using System.IO;
using System.Data;

namespace kioskotem
{
    public partial class Soporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               
            }

        }

        protected void cmdrecuperar_Click(object sender, EventArgs e)
        {

            String nombre = txtnombre.Text;
            String correo = txtcorreo.Text;
            String usuario = txtusuario.Text;
            String descripcion = txtdescripcion.Text;


            string enviosoporte = EnviarCorreos.envioSoporte(usuario, nombre, descripcion , correo);
            string asuntoConfirmar = "Contacto Soporte del usuario "+ nombre;

            if (EnviarCorreos.enviarCorreo("soporte@mbcgroup.mx", enviosoporte, asuntoConfirmar) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "mensaje",
                "alert('Error, no se pudo enviar el correo!');", true);
            }
            else
            {
                //Response.Redirect("~/ClienteRegistrado.aspx");

               // ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Se ha enviado correctamente.');", true)

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "validarart();", true);

     
            }

         }

       

       

    }
}
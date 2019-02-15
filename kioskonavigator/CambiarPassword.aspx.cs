using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kioskotem.wcfoperadora;
using System.Net.Mail;
using System.IO;

namespace kioskotem
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string claveAcceso = Request.QueryString["ca"];

           
            if (!IsPostBack)
            {
                try
                {
                    IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();
                     Tabla ValidarConfirmacion = Manejador.getEjecutaStoredProcedure1("UP_S_ValidarConfirmacionPass", claveAcceso);

                    if (ValidarConfirmacion != null)
                    {
                       // ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Ocurrio un error intente mas tarde');", true);
                    }
                }
                catch (Exception EX)
                {
                   ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
                   
                  Session.Abandon();
                     Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                     Response.Redirect("Default.aspx");  
               
                }
           
            }
            else
            {
                
                   /* Session.Abandon();
                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    Response.Redirect("Default.aspx");  */
               
            }

          
          
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text == txtConfirmar.Text)
                {

                    //Actualizar Contraseña
                    IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();
                    Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setActualizarPass", txtCodigo.Text.Replace(" ", "X") + "|" + txtPass.Text.Replace(" ", "X"));

                    if (MiTabla != null)
                    {
                        DateTime thisDay = DateTime.Today;
                        Tabla MiTabla2 = Manejador.getEjecutaStoredProcedure1("setActualizarFechaPass", txtCodigo.Text.Replace(" ", "X") + "|" + thisDay.ToShortDateString());
                        if (MiTabla2 != null)
                        {
                         //   
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Se actualizado correctamente');", true);
                                Response.Redirect("inicio/inicio.aspx");

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Hubo un error al actualizar');", true);

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Hubo un error al actualizar');", true);

                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Las contraseñas no coiciden');", true);

                }
            }
            catch (Exception EX)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
            }
           
        }

        
    }
}
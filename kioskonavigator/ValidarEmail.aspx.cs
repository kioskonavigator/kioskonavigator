using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfoperadora;
using System.Net.Mail;
using System.IO;

namespace kioskotem
{
    public partial class ValidarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objusuario"] == null)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Redirect("default.aspx");
            }

        }

      

        protected void cmdenviar_Click(object sender, EventArgs e)
        {

            try 
            {
                    string claveacceso = Generador.ClaveAccesoUsuario(15);
                    IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();
           
                    Tabla UpdateTable = Manejador.getEjecutaStoredProcedure1("UP_S_ActualizarClaveAcceso", Session["idusuario"].ToString() + "|" + Session["idcodigo"].ToString() + "|" + claveacceso);

                    if (UpdateTable != null)
                    {
                        Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("UP_S_ValidarClaveAcceso", claveacceso);

              

                        if (MiTabla != null)
                        {
                            Tabla MiTabla1 = Manejador.getEjecutaStoredProcedure1("setActualizarEmail", Session["idusuario"].ToString() + "|" + Session["idcodigo"].ToString() + "|" + txtCorreo.Text.Replace(" ", "X"));
                    
                            DataTable clValidarClaveAcceso = clFunciones.convertToDatatable(MiTabla1);
                            if (MiTabla != null)
                            { 
                                String mail = txtCorreo.Text;
                                String nombrec = clValidarClaveAcceso.Rows[0]["nombrec"].ToString();
                       

                                enviarCorreo(claveacceso, mail,    nombrec);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Este correo no esta asociado a su cuenta');", true);
                        }
                     }

                }
                catch (Exception EX)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
                }
                   

    }


        public void enviarCorreo(String clavedeacceso, String CorreoContacto, String nombreContacto)
        {
            string paginaConfirmacion = EnviarCorreos.paginaConfirmar(nombreContacto,  "Navigator ", clavedeacceso);

            string asuntoConfirmar = "Bienvenido a " + "Navigator" + "!";

            if (EnviarCorreos.enviarCorreo(CorreoContacto, paginaConfirmacion, asuntoConfirmar) == false)
            {

                ScriptManager.RegisterStartupScript(this, typeof(string), "mensaje",
                "alert('Error, no se pudo enviar el correo!!!');", true);
            }
            else
            {

                //Response.Redirect("~/ClienteRegistrado.aspx");

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "validarart();", true);

               
               
            }

        }
       
    }
}
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
    public partial class Recuperar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
               
            }

        }

        protected void cmdrecuperar_Click(object sender, EventArgs e)
        {
           
            String mail = txtcorreo.Text;
           
                string claveacceso = Generador.ClaveAccesoUsuario(15);

                //Validar su  usuarios
                 IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();
                Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("getValidarEmail", txtusuario.Text.Replace(" ", "X") + "|" + mail);
                if (MiTabla != null)
                {

                    Tabla UpdateTable = Manejador.getEjecutaStoredProcedure1("UP_S_ActualizarClaveAccesoPass", txtusuario.Text.Replace(" ", "X") + "|" + claveacceso);

                    if (UpdateTable != null)
                    {
                        Tabla validarCA = Manejador.getEjecutaStoredProcedure1("UP_S_ValidarClaveAccesoPass", claveacceso);



                        if (validarCA != null)
                        {

                            DataTable clValidarClaveAcceso = clFunciones.convertToDatatable(UpdateTable);

                            //String mail = clValidarClaveAcceso.Rows[0]["email"].ToString();
                            String nombrec = clValidarClaveAcceso.Rows[0]["nombrec"].ToString();


                            enviarCorreo(claveacceso, mail, nombrec);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Este correo no esta asociado a su cuenta');", true);
                        }
                    }
                
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Este correo no esta asociado a su cuenta');", true);
                }


           
           

         }

        public void enviarCorreo(String clavedeacceso, String CorreoContacto, String nombreContacto)
        {
            string paginaRecuperar = EnviarCorreos.paginaRecuperar(nombreContacto, clavedeacceso);
            string asuntoConfirmar = "Navigator" + "Cambiar Contraseña" + "!";

            if (EnviarCorreos.enviarCorreo(CorreoContacto, paginaRecuperar, asuntoConfirmar) == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "mensaje",
                "alert('Error, no se pudo enviar el correo!!!');", true);
            }
            else
            {
                //Response.Redirect("~/ClienteRegistrado.aspx");

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Revise su correo electronico se le ha enviado un mensaje de verificación.');", true);

            }

        }

       

    }
}
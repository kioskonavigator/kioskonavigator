using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using kioskotem.wcfoperadora;
using System.Data;

namespace kioskotem.configurar
{
    public partial class correo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdguardar_Click(object sender, EventArgs e)
        {
            try
            {
                IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();

                //  Tabla UpdateTable = Manejador.getEjecutaStoredProcedure1("UP_S_ActualizarClaveAcceso", Session["idusuario"].ToString() + "|" + Session["idcodigo"].ToString() + "|" + claveacceso);

                Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setActualizarEmail", Session["idusuario"].ToString() + "|" + Session["idcodigo"].ToString() + "|" + txtmailnew.Text.Replace(" ", "X"));

                DataTable clValidarClaveAcceso = clFunciones.convertToDatatable(MiTabla);
                if (MiTabla != null)
                {
                    String mail = txtmailnew.Text;
                    String nombrec = clValidarClaveAcceso.Rows[0]["nombrec"].ToString();


                enviarCorreo("Clave", mail, nombrec);
                }

            }
            catch (Exception EX)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
            }
        }





        public void enviarCorreo(String clavedeacceso, String CorreoContacto, String nombreContacto)
        {
            string paginaCambio = EnviarCorreos.paginaCambio(nombreContacto);

            string asuntoConfirmar = "Cambio de correo en OperadoraMx.net";

            if (EnviarCorreos.enviarCorreo(CorreoContacto, paginaCambio, asuntoConfirmar) == false)
            {

                ScriptManager.RegisterStartupScript(this, typeof(string), "mensaje",
                "alert('Error, no se pudo enviar el correo!!!');", true);
            }
            else
            {

                //Response.Redirect("~/ClienteRegistrado.aspx");

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Se ha actualizado correctamente su correo.');", true);

            }

        }
    }
}
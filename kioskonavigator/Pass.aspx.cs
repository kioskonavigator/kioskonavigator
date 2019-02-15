using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using kioskotem.wcfoperadora;

namespace kioskotem
{
    public partial class Pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable usuario = (DataTable)Session["objusuario"];
            if (!IsPostBack)
            {
                try
                {
                    txtusuario.Text = usuario.Rows[0]["codigo"].ToString();
                }
                catch (Exception EX)
                {
                  Session.Abandon();
                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    Response.Redirect("Default.aspx");  
                }

                
            }
            else
            {

             /*   Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Redirect("Default.aspx");  */

            }
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtConfirmar.Text)
            {

                //Actualizar Contraseña
                IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();
                Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setActualizarPass", txtusuario.Text.Replace(" ", "X") + "|" + txtPass.Text.Replace(" ", "X"));

                if (MiTabla != null)
                {
                    DateTime thisDay = DateTime.Today;
                    Tabla MiTabla2 = Manejador.getEjecutaStoredProcedure1("setActualizarFechaPass", txtusuario.Text.Replace(" ", "X") + "|" + thisDay.ToShortDateString());
                    if (MiTabla2 != null)
                    {
                        
                        Session.Abandon();
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        Response.Redirect("inicio/inicio.aspx");   
                        //Response.Redirect("Default.aspx");
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

    }
}
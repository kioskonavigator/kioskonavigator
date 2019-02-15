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
    public partial class Verificar : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {  
            //insertamos la modificacion en la base de datos
           
                
                string claveAcceso = Request.QueryString["ca"];



                if (!IsPostBack)
                {
                    try
                    {
                        IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();
                        Tabla ValidarConfirmacion = Manejador.getEjecutaStoredProcedure1("UP_S_ValidarConfirmacion", claveAcceso);
                        if (ValidarConfirmacion != null)
                        {

                            Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setVerificarEmail", claveAcceso);

                            if (MiTabla != null)
                            {


                            }
                            else
                            {
                                Response.Redirect("Verificar.aspx");
                                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Datos no guardados, intente de nuevo');", true);
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "mensaje", "alert('Error!!! " + ex.Message + " ');", true);

                    }
                    //else
                    // {
                    //    Session.Abandon();
                    //    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    //    Response.Redirect("../default.aspx");
                    //  //  }




                }
                else 
                {
                    Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                //Response.Redirect("Verificar.aspx");
                Response.Redirect("inicio/inicio.aspx");
                }
               
                   
                    
        }

        protected void cmdIniciar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
             Response.Redirect("../default.aspx");

        }

    }
}
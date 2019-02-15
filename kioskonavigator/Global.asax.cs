using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace kioskotem
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["objusuario"] = null;
            Session["idusuario"] = "";
            //Session["dsPagos"] = new System.Data.DataSet();
            //Session["dsAnticipo"] = new System.Data.DataSet();
            //Session["dsViaje"] = new System.Data.DataSet();
            Session["idcodigo"] = "";
            Session["ruta"] = "";
            Session["archivo"] = "";
            Session["archivoxml"] = "";
            Session["xml"] = "";
            Session["ruta2"] = "";
            Session["inicio"] = "";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
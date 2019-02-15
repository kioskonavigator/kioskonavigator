using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kioskotem.configurar
{
    public partial class Actualizar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objusuario"] == null)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Redirect("../default.aspx");
            }
            
        }

        protected void cmdcontra_Click(object sender, EventArgs e)
        {
            Response.Redirect("contra.aspx");
        }

        protected void cmdCambiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("correo.aspx");
        }
    }
}
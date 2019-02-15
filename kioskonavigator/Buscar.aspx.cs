using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using kioskotem.wcfoperadora;

namespace kioskotem.usuario
{
    public partial class Buscar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargar_clientes();


            }

        }




        private void cargar_clientes()
        {
            IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();

            Tabla TablaEmpresas = Manejador.getEjecutaStoredProcedure1("getUsuariosSeleccionar", "1");
            cboClientes.Items.Clear();

            if (TablaEmpresas != null)
            {
                System.Data.DataTable dtusuario = clFunciones.convertToDatatable(TablaEmpresas);
                for (int x = 0; x < dtusuario.Rows.Count; x++)
                {
                    cboClientes.Items.Add(new ListItem(dtusuario.Rows[x]["nombrec"].ToString(), dtusuario.Rows[x]["IidUsuarioK"].ToString()));//, dtusuario.Rows[x]["codigo"].ToString(), dtusuario.Rows[x]["Password"].ToString()));
                     Session["objusuario"] = dtusuario;
                     Session["idusuario"] = dtusuario.Rows[0]["IidUsuarioK"].ToString();
                     Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                     Session["inicio"] = "1";

            //Response.Redirect("inicio/inicio.aspx");
                }
            }
            else
            {
                cboClientes.Items.Add(new ListItem("Sin usuarios", "-1"));

            }
        }

        protected void cmdIniciar_Click(object sender, EventArgs e)
        {
            IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient();

            Tabla TablaCliente = Manejador.getEjecutaStoredProcedure1("getUsuariosSeleccionarCliente", cboClientes.SelectedValue);

            System.Data.DataTable dtusuario = clFunciones.convertToDatatable(TablaCliente);

            Session["objusuario"] = dtusuario;
            Session["idusuario"] = dtusuario.Rows[0]["iIdUsuarioK"].ToString();
            //Session["idtmp"] = dtusuario.Rows[0]["iIdClienteAcceso"].ToString();
            Session["usuario"] = dtusuario.Rows[0]["codigo"].ToString();
            Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
            Session["inicio"] = "0";
            Response.Redirect("inicio/inicio.aspx");
        }

    }
}
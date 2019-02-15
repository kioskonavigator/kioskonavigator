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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient(); 
                Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("getvalidarusuarioK", txtcodigo.Text.Replace(" ", "X") + "|" + txtusuario.Text.Replace(" ", "X") + "|" + txtcontra.Text.Replace(" ", "X"));
               
                
                if (MiTabla != null)                
                {
                    DataTable dtusuario = clFunciones.convertToDatatable(MiTabla);
                    if (dtusuario.Rows[0]["iEstatus"].ToString() == "2")
                    {

                        Response.Redirect("Buscar.aspx");

                    }
                    else
                    {
                        if (dtusuario.Rows[0]["privacidad"].ToString() == "0")
                            {
                                Session["objusuario"] = dtusuario;
                                Session["idusuario"] = dtusuario.Rows[0]["iIdUsuarioK"].ToString();
                                Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                                Response.Redirect("privacidad.aspx");
                            }
                            else
                            {
                                if (dtusuario.Rows[0]["etica"].ToString() == "0")
                                {
                                    Session["objusuario"] = dtusuario;
                                    Session["idusuario"] = dtusuario.Rows[0]["iIdUsuarioK"].ToString();
                                    Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                                    Response.Redirect("etica.aspx");
                                }
                                    //ValidateMail
                                else
                                {
                                    if (dtusuario.Rows[0]["verificaremail"].ToString() == "0")
                                    {
                                        Session["objusuario"] = dtusuario;
                                        Session["idusuario"] = dtusuario.Rows[0]["iIdUsuarioK"].ToString();
                                        Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                                        Response.Redirect("ValidarEmail.aspx");
                                    }
                                    else
                                    {
                      
                                        Session["objusuario"] = dtusuario;
                                        Session["idusuario"] = dtusuario.Rows[0]["iIdUsuarioK"].ToString();
                                        Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                                        Session["inicio"] = "1";
                                        Response.Redirect("inicio/inicio.aspx");

                               
                               
                                    }
                                }
                            }
                    }



                    

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Usuario o contraseña incorrecta');", true);
                }


            }
            catch (Exception EX)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recuperar.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Soporte.aspx");
        }
    }
}
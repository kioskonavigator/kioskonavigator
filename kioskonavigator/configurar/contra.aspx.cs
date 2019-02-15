using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfoperadora ;

namespace kioskotem.configurar
{
    public partial class contra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objusuario"] == null)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Redirect("../default.aspx");
            }
            if (!IsPostBack)
            {
                
                txtid.Text = Session["idcodigo"].ToString();
                txtusuario.Text = Session["idcodigo"].ToString();
            }
        }

        protected void cmdguardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime thisDay = DateTime.Today;

                //verificamos que el id empleado y usuario sean iguales
                if (txtid.Text == txtusuario.Text)
                {
                    //verificamos que coincida con su usuario actual
                    if (txtusuario.Text == Session["idcodigo"].ToString())
                    {
                        //Validamos contraseñas iguales
                        if (txtpass.Text == txtrepass.Text)
                        {
                            //hacemos la actualizacion en la base de dato
                            IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient(); 
                            Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setActualizarContra", Session["idusuario"].ToString() + "|" + txtusuario.Text + "|" + txtpass.Text);
                            if (MiTabla != null)
                            {
                                //Guardar Fecha de pass
                                //DateTime thisDay = DateTime.Today;
                                Tabla MiTabla2 = Manejador.getEjecutaStoredProcedure1("setActualizarFechaPass", txtusuario.Text.Replace(" ", "X") + "|" + thisDay.ToShortDateString());

                                if (MiTabla2 != null)
                                {
                                   
                                       
                                            //DataTable dtusuario = clFunciones.convertToDatatable(MiTabla);
                                            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('La nueva contraseña se guardo correctamente');", true);
                                            txtid.Text = "";
                                            txtusuario.Text = "";
                                            txtpass.Text = "";
                                            txtrepass.Text = "";
                                      
                                }

                              
                    

                            }
                            //else
                            //{
                            //    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('La nueva contraseña se guardo correctamente');", true);
                            //}


                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('Las contraseñas no coinciden');", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('El id empleado y usuario no corresponden al asignado a ti.');", true);

                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('El id empleado y usuario deben ser iguales.');", true);
                }
            


            }
            catch (Exception EX)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
            }
            
            
        }
    }
}
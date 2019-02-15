using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ConfirmarRegistro : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
      /*   Persistencia capad = (Persistencia)Session["Persistencia"];

        ((DatosRegistro.OtrosDatos)Session["OtrosDatos"]).Registro = "registro";
        //Session["registro"] = "registro";
        //string claveAcceso = "gfRPr4gk";
        string claveAcceso = Request.QueryString["ca"];
        if (!IsPostBack)
        {

            #region Validar Confirmación

            if (CapaDatos.Conectado(ref capad))
            {
                Session["Persistencia"] = capad;
                parametroPA[] aParametros = capad.getConstruirParametros(1);
                aParametros[0].Establecer("@claveAcceso", direccion.entrada, dbTipo.NVarChar, 50, claveAcceso);
                cl_Tabla ValidarConfirmacion = capad.getTablaSProcDS("UP_S_ValidarConfirmacion", aParametros);
                if (ValidarConfirmacion != null)
                {
                    if (ValidarConfirmacion.Filas != null)
                    {
                        if (ValidarConfirmacion.convertToDatatable().Rows[0][0].ToString() == "")
                        {
                            lblTexto.Text = "Su solicitud ya est&aacute; siendo procesada.<br />En breve un(a) asesor(a)a se comunicar&aacute; con usted para continuar el proceso de registro.";
                            return;
                        }

                        int Valida = int.Parse(ValidarConfirmacion.convertToDatatable().Rows[0][0].ToString());
                        string cCorreoContacto = ValidarConfirmacion.convertToDatatable().Rows[0][1].ToString();

                        if (Valida != 0)
                        {
                            string claveAccesoHash = Validador.CalcularHash(claveAcceso);

                            try
                            {
                                ((DatosRegistro.DatosContacto)Session["DatosContacto"]).cContactoClaveAccesoHash = claveAccesoHash;
                                Session["Persistencia"] = capad;

                                parametroPA[] crParametros = capad.getConstruirParametros(11);
                                //Entrada
                                crParametros[0].Establecer("@CorreoContacto", direccion.entrada, dbTipo.NVarChar, 100, cCorreoContacto);
                                crParametros[1].Establecer("@ClaveAcceso", direccion.entrada, dbTipo.NVarChar, 100, claveAcceso);
                                crParametros[2].Establecer("@ClaveAccesoHash", direccion.entrada, dbTipo.NVarChar, 100, claveAccesoHash);
                                //Salida
                                //Datos Contacto
                                crParametros[3].Establecer("@ContactoNombres", direccion.salida, dbTipo.NVarChar, 100, "0");
                                crParametros[4].Establecer("@ContactoApellidos", direccion.salida, dbTipo.NVarChar, 100, "0");
                                //Datos Empresa
                                crParametros[5].Establecer("@EmpresaId", direccion.salida, dbTipo.Int, 0, 0);
                                crParametros[6].Establecer("@EmpresaNombre", direccion.salida, dbTipo.NVarChar, 150, "0");
                                crParametros[7].Establecer("@EmpresaUrl", direccion.salida, dbTipo.NVarChar, 150, "0");
                                //Datos Producto
                                crParametros[8].Establecer("@ProductoNombre", direccion.salida, dbTipo.NVarChar, 150, "0");
                                crParametros[9].Establecer("@ProductoAcronimo", direccion.salida, dbTipo.NVarChar, 5, "0");
                                //Datos Activacion
                                crParametros[10].Establecer("@TipoActivacion", direccion.salida, dbTipo.NVarChar, 50, "0");

                                capad.getEscalarDeSProc("UP_SUI_ConfirmarRegistro", crParametros);

                                //Datos de Contacto
                                ((DatosRegistro.DatosContacto)Session["DatosContacto"]).cContactoNombres = crParametros[3].getParametroNativoSQL().Value.ToString();
                                ((DatosRegistro.DatosContacto)Session["DatosContacto"]).cContactoApellidos = crParametros[4].getParametroNativoSQL().Value.ToString();
                                ((DatosRegistro.DatosContacto)Session["DatosContacto"]).cContactoClaveAccesoHash = claveAccesoHash;
                                //Datos de Empresa
                                ((DatosRegistro.DatosEmpresa)Session["DatosEmpresa"]).iEmpresaId = crParametros[5].getParametroNativoSQL().Value.ToString();
                                ((DatosRegistro.DatosEmpresa)Session["DatosEmpresa"]).cEmpresaNombre = crParametros[6].getParametroNativoSQL().Value.ToString();
                                ((DatosRegistro.DatosEmpresa)Session["DatosEmpresa"]).cEmpresaURL = crParametros[7].getParametroNativoSQL().Value.ToString();
                                //Datos de Producto
                                ((DatosRegistro.DatosProducto)Session["DatosProducto"]).cProductoNombre = crParametros[8].getParametroNativoSQL().Value.ToString();
                                ((DatosRegistro.DatosProducto)Session["DatosProducto"]).cProductoAcronimo = crParametros[9].getParametroNativoSQL().Value.ToString();
                                ((DatosRegistro.OtrosDatos)Session["OtrosDatos"]).cActivacionTipoActivacion = crParametros[10].getParametroNativoSQL().Value.ToString();

                                Response.Redirect("~/RegistroConfirmado.aspx");

                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "mensaje", "alert('Error!!! " + ex.Message + " ');", true);
                                lblerror.Text = ex.Message;
                            }
                        }
                        else
                        {
                            lblTexto.Text = "Su solicitud ya est&aacute; siendo procesada.<br />En breve un(a) asesor(a)a se comunicar&aacute; con usted para continuar el proceso de registro.";
                        }
                    }
                }
            }

            #endregion

        }*/
    }
}
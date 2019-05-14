using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;

using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfoperadora; 

/// <summary>
/// Descripci&oacute;n breve de EnviarCorreos
/// </summary>
public class EnviarCorreos
{
	public EnviarCorreos()
	{
   
        //
		// TODO: Agregar aqu&iacute; la l&oacute;gica del constructor
		//
	}

    static string mensajeError = "";
    public static Boolean enviarCorreo(string email, string pagina, string asunto)
    {
        //MailMessage correo = new MailMessage();
        //correo.From = new MailAddress("raymundo.schulz@contanetica.com");
        //correo.To.Add(email);
        //correo.Subject = asunto;
        ////correo.Body = leerPaginaWeb(pagina);
        //correo.Body = pagina;
        //correo.IsBodyHtml = true;
        ////correo.Priority = MailPriority.Normal();
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "contanetica.com";
        try
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
           // msg.From = new MailAddress("omar.perez@co ntanetica.com", "Operadora Mx", Encoding.UTF8);
            msg.From = new MailAddress("soporte@mbcgroup.mx", "Navigator", Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = pagina;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("omar.perez@contanetica.com", "omarp");
            client.Credentials = new System.Net.NetworkCredential("soporte@mbcgroup.mx", "@tortadejamon");
            client.Port = 26;
            //client.Host = "contanetica.com";
            client.Host = "mbcgroup.mx";
            //client.EnableSsl = true; //Esto es para que vaya a través de SSL

            client.Send(msg);

            //smtp.Send(correo);
            return true;
            //Response.Write("Correo Enviado");
        }
        catch (Exception ex)
        {
            mensajeError = "No se pudo enviar el correo " + ex.Message;
            return false;
        }
    }

    //public static string paginaCliente(string nombres, string apellidos, string correo, string passwd, string producto, string imgproducto)
    public static string paginaConfirmar(string NombresContacto,  string NombreProducto,  string ClaveAcceso)
    {
        string confirmacionCliente=
        @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +

            "<html xmlns='http://www.w3.org/1999/xhtml'>" +
            "<head>" +
                "<title></title>" +
                "<link href='http://avizorregistro.contanetica-saas.com/Styles/Style.css' rel='stylesheet' type='text/css' />" +
            "</head>" +
            "<body style='background-color:#FFFFFF;'>" +

            "<div class='plantilla'>" +
                "<div class='banner'><img src='http://www.operadoramx.net/operadora/imagenes/logooperadora.png  ' alt='" + NombreProducto + "' /></div>" +
                "<div class='titulo'>Gracias por registrarse.</div>" +
                "<div class='contenido'>" +
                    "<p>" +
                        "Estimado: <strong>" + NombresContacto + " " + "</strong>" +
                        "<br />" +
                        "Para continuar con el proceso de registro en <strong>" + NombreProducto + "</strong>, es necesario nos confirme haciendo click en el siguiente link " +
                        "<br />" +
                        "<span style='text-align:center;'><a href='http://www.navigatorlamda.net/navigator/Verificar.aspx?ca=" + ClaveAcceso + "' target='_new'>http://www.navigatorlamda.net/navigator/Verificar.aspx</a></span>" +
                        "<br />" +
                        "o copie y pegue el contenido en la barra de navegaci&oacute;n de su explorador." +
                    "</p>" +
                "</div>" +
                "<div align='center'>" +
                    "<p>" + 
                    "Este correo se genera de manera automatica. Porfavor, no responda." +
                    "</p>" +
                    "</div>" +
            "</div>" +

            "</body>" +
            "</html>";
        return confirmacionCliente;
    }


    public static string paginaRecuperar(string NombresContacto,  string ClaveAcceso)
    {
        string confirmacionCliente =
        @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +

           "<html xmlns='http://www.w3.org/1999/xhtml'>" +
           "<head>" +
               "<title></title>" +
               
           "</head>" +
           "<body style='background-color:#FFFFFF;'>" +

           "<div class='plantilla'>" +
               "<div class='banner'><img src='http://www.operadoramx.net/operadora/imagenes/logooperadora.png  ' alt='Operadora Mx' /></div>" +
               "<div class='titulo'>Gracias por registrarse.</div>" +
               "<div class='contenido'>" +
                   "<p>" +
                       "Estimado: <strong>" + NombresContacto + " " + "</strong>" +
                       "<br />" +
                       "Para continuar con el proceso de registro en <strong>Operadora Mx</strong>, es necesario nos confirme haciendo click en el siguiente link " +
                       "<br />" +
                       "<span style='text-align:center;'><a href='http://www.navigatorlamda.net/navigator/CambiarPassword.aspx?ca=" + ClaveAcceso + "' target='_new'>http://www.operadoramx.net/operadora/CambiarPassword.aspx</a></span>" +
                       "<br />" +
                       "o copie y pegue el contenido en la barra de navegaci&oacute;n de su explorador." +
                   "</p>" +
               "</div>" +
               "<div align='center'>" +
            /* "<img src='http://avizorregistro.contanetica-saas.com/imagenes/pie.jpg' alt='Contan&eacute;tica S.A. de C.V.' />" +*/
               "</div>" +
           "</div>" +

           "</body>" +
           "</html>";
        return confirmacionCliente;
    }



    public static string paginaCambio(string NombresContacto)
    {
        string confirmacionCliente =
        @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +

            "<html xmlns='http://www.w3.org/1999/xhtml'>" +
            "<head>" +
                "<title></title>" +
                "<link href='http://avizorregistro.contanetica-saas.com/Styles/Style.css' rel='stylesheet' type='text/css' />" +
            "</head>" +
            "<body style='background-color:#FFFFFF;'>" +

            "<div class='plantilla'>" +
                "<div class='banner'><img src='http://www.operadoramx.net/operadora/imagenes/logooperadora.png  ' alt='" + " " + "' /></div>" +
                "<div class='titulo'></div>" +
                "<div class='contenido'>" +
                    "<p>" +
                        "Estimado: <strong>" + NombresContacto + " " + "</strong>" +
                        "<br />" +
                        "<br />" +
                        "Se ha vinculado este correo a su cuenta en <strong>www.operadoramx.net</strong>  correctamente" +
                    "</p>" +
                "</div>" +
                "<div align='center'>" +
                    "<p>" +
                    "Este correo se genera de manera automatica. Porfavor, no responda." +
                    "</p>" +
                    "</div>" +
            "</div>" +

            "</body>" +
            "</html>";
        return confirmacionCliente;
    }


    public static string envioSoporte(string codigo, string nombre, string mensaje, string correo)
    {
        string CuerpoMail;

        CuerpoMail = "";
        CuerpoMail = "<html>";
        CuerpoMail += "<head>";
        CuerpoMail += "<title>Operadora Mx </title>";
        CuerpoMail += "</head>";
        CuerpoMail += "<body>";
        CuerpoMail += "<form>";
        CuerpoMail += "<div>";
        CuerpoMail += "<table border='1' cellspacing='0' cellpadding='2' bordercolor='000000' style=' width :700px; height : auto ; margin : 0 auto; border: 1px solid #000; font-size :11px; font-family :Verdana ;' >";
        CuerpoMail += "<tr>";
        CuerpoMail += "<td colspan='2'>";
        CuerpoMail += "Tiene un comentario o problema el usuario: " + correo;
        CuerpoMail += "</td>";
        CuerpoMail += "</tr>";
        CuerpoMail += "<tr>";
        CuerpoMail += "<td colspan='2' align='center'>";
        CuerpoMail += "<strong>Datos del empleado</strong>";
        CuerpoMail += "</td>";
        CuerpoMail += "</tr>";
        CuerpoMail += "<tr style='" + "font-weight :bold ;" + "'>";
        CuerpoMail += "<td style='" + "text-align:center; " + "'>Codigo Empleado</td>";
        CuerpoMail += "<td style='" + "text-align:center;'" + ">" + codigo + "</td>";
        CuerpoMail += "</tr>";
        CuerpoMail += "<tr style='" + "font-weight :bold ;" + "'>";
        CuerpoMail += "<td style='" + "text-align:center; " + "'>Usuario:</td>";
        CuerpoMail += "<td style='" + "text-align:center;'" + ">" + nombre + "</td>";
        CuerpoMail += "</tr>";

        CuerpoMail += "<tr style='" + "font-weight :bold ;" + "'>";
        CuerpoMail += "<td style='" + "text-align:center; " + "'>Mensaje: </td>";
        CuerpoMail += "<td style='" + "text-align:center;'" + ">" + mensaje + "</td>";
        CuerpoMail += "</tr>";

        CuerpoMail += "</table>";
        CuerpoMail += "</div>";
        CuerpoMail += "</form>";
        CuerpoMail += "</body>";
        CuerpoMail += "</html>";




        return CuerpoMail;



    }


}
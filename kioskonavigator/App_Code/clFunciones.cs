using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfoperadora ; 


/// <summary>
/// Descripción breve de clFunciones
/// </summary>
/// 

public enum TipoMensaje
{
	Alerta = 0,
	Error = 1,
	Informacion = 2

}

public class clFunciones
{
	public clFunciones()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

	/// <summary>
	/// Mostrar mensaje en formato JQUERY, No olvide hacer referencia a los scripts de JQUERY
	/// </summary>
	/// <param name="Pagina"></param>
	/// <param name="Mensaje"></param>
	/// <param name="Caption"></param>
	/// <param name="Tipo"></param>
	static public void JQMensaje(System.Web.UI.Page Pagina, string Mensaje, TipoMensaje Tipo = TipoMensaje.Informacion, string Caption = "Información del sistema", string AlterScript = "")
	{
		string Script = "";
        
		switch (Tipo)
		{
			case TipoMensaje.Informacion:
				Script = "Sexy.info"; break;
			case TipoMensaje.Alerta:
				Script = "Sexy.alert"; break;
			case TipoMensaje.Error:
				Script = "Sexy.error"; break;
		}

		Script = Script + "('<h1>" + Caption + "</h1><p>" + Mensaje + "</p>');";
		System.Web.UI.ScriptManager.RegisterStartupScript(Pagina, typeof(string), "Mensaje", Script + ' ' + AlterScript, true);
	}

	static public void JQMensaje(System.Web.UI.UpdatePanel Panel, string Mensaje, TipoMensaje Tipo = TipoMensaje.Informacion, string Caption = "Información del sistema", string AlterScript = "")
	{
		string Script = "";

		switch (Tipo)
		{
			case TipoMensaje.Informacion:
				Script = "Sexy.info"; break;
			case TipoMensaje.Alerta:
				Script = "Sexy.alert"; break;
			case TipoMensaje.Error:
				Script = "Sexy.error"; break;
		}

		Script = Script + "('<h1>" + Caption + "</h1><p>" + Mensaje + "</p>');";
		System.Web.UI.ScriptManager.RegisterStartupScript(Panel, typeof(string), "Mensaje", Script + ' ' + AlterScript, true);
	}

    //static public void CargarEstados(ref DropDownList Combo)
    //{
    //    DataSet dsEstados = new DataSet();
    //    EmpresaServicio.SvcEmpresaClient Consulta = new EmpresaServicio.SvcEmpresaClient();

    //    DataTable MiTabla =  Consulta.getEstados(1); 
    //    if(MiTabla!=null)
    //    {
    //            dsEstados.Tables.Add(MiTabla);
    //            if (dsEstados.Tables.Count > 0)
    //            {			
    //                Combo.DataSource = dsEstados.Tables[0];
    //                Combo.DataTextField = "sNombre";
    //                Combo.DataValueField = "iIdEstado";
    //                Combo.DataBind();
    //            }
    //    }

    //}

	public static string MonthName(int iMes, bool Abrevia = false)
	{
		if (iMes > 0 && iMes < 13)
		{
			string Nombre = DateTime.Parse("01/" + iMes.ToString("00") + "/2010").ToString("MMMM");
			Nombre = Nombre.Substring(0, 1).ToUpper() + Nombre.Substring(1).ToLower();
			return Abrevia ? Nombre.Substring(0, 3) : Nombre;
		}
		return "Desconocido";
	}


	public static void  MostrarMSG(string Mensaje, System.Web.UI.Page Pagina)
	{
			System.Web.UI.ScriptManager.RegisterStartupScript(Pagina, typeof(string), "script1", "alert('"+  Mensaje +"');", true);
	}

	public static void MostrarMSG(string Mensaje, System.Web.UI.UpdatePanel Panel)
	{
		System.Web.UI.ScriptManager.RegisterStartupScript(Panel, typeof(string), "script1", "alert('" + Mensaje + "');", true);
	}


	public static void Confirmacion(string Mensaje, System.Web.UI.Page Pagina, string BotonNombreYES, string BotonNombreNO = "")
	{
		string Script = @"Sexy.confirm('" + Mensaje + "', {onComplete:" +
		   "  function(returnvalue) { " +
		   "  if(returnvalue)" +
		   "  {              " +
		   "      document.getElementById('" + BotonNombreYES + "').click();" +
		   "  }          " + (BotonNombreNO != "" ? " else{document.getElementById('" + BotonNombreNO + "').click(); }" : "") +
		   "  }});";


		System.Web.UI.ScriptManager.RegisterStartupScript(Pagina, typeof(string), "alerta", Script, true);
	}


	public static void Confirmacion(string Mensaje, System.Web.UI.UpdatePanel Panel, string BotonNombreYES, string BotonNombreNO = "")
	{
		string Script = @"Sexy.confirm('" + Mensaje + "', {onComplete:" +
		   "  function(returnvalue) { " +
		   "  if(returnvalue)" +
		   "  {              " +
		   "      document.getElementById('" + BotonNombreYES + "').click();" +
		   "  }          " + (BotonNombreNO != "" ? " else{document.getElementById('" + BotonNombreNO + "').click(); }" : "") +
		   "  }});";

		System.Web.UI.ScriptManager.RegisterStartupScript(Panel, typeof(string), "alerta", Script, true);
	}

    static public DataTable convertToDatatable(Tabla tabla, string TableName = "Table", bool Decimales = false, bool NoDecimals = true )
    {

        if (!(tabla == null))
        {
            if (tabla.Columnas != null)
            {
                DataTable Tabla = new DataTable();

                DataColumn[] aColumn;
                aColumn = (from c in tabla.Columnas select new DataColumn(c )).ToArray();
                Tabla.Columns.AddRange(aColumn);
                IEnumerable<DataRow> Query;

                if (Decimales)
                {
                    double iValor;
                    string sDecimal = (NoDecimals?".00":"");
                    Query = from Fila fila in tabla.Filas select Tabla.Rows.Add((from string Dato in fila.Campos select (double.TryParse(Dato,out iValor)?iValor.ToString("#,###,##0"+sDecimal):Dato) ).ToArray());
                }
                else
                {
                    Query = from Fila fila in tabla.Filas select Tabla.Rows.Add((from string Dato in fila.Campos select Dato).ToArray());
                }

                DataRow[] Filas;
                Filas = Query.ToArray();
                Tabla = Filas.CopyToDataTable();
                Tabla.TableName = TableName;
                return Tabla;
            }

        }
        return null;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Security.Cryptography;

using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfoperadora; 

/// <summary>
/// Descripción breve de Validador
/// </summary>
public class Validador
{
	public Validador()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static Boolean password_ok(string passwd)
    {
        string expresion = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,12}$";
        if (Regex.IsMatch(passwd, expresion))
        {
            if (Regex.Replace(passwd, expresion, string.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static string CalcularHash(string Cadena)
    {
        try
        {
            int i;
            HashAlgorithm Hash = new MD5CryptoServiceProvider();
            byte[] Devolver = Encoding.ASCII.GetBytes(Cadena);
            StringBuilder sb;

            sb = new StringBuilder(Devolver.Length);
            for (i = 0; i < Devolver.Length; i++)
            {
                sb.Append(Devolver[i].ToString("X2"));
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public static string ByteToString(byte[] buff)
    {
        string sbynary = "";
        for (int i = 0; i < buff.Length; i++)
        {
            sbynary += buff[i].ToString("x2");//formato hexadecimal
        }
        return (sbynary);
    }

}
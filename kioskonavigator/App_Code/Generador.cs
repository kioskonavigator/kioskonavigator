using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfoperadora; 


using System.IO;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Descripción breve de Generador
/// </summary>
public class Generador
{
	public Generador()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static string ClaveAccesoUsuario(int longitud)
    {
        string _allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        Byte[] randomBytes = new Byte[longitud];
        char[] chars = new char[longitud];
        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < longitud; i++)
        {
            Random randomObj = new Random();
            randomObj.NextBytes(randomBytes);
            chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
        }
        return new string(chars);
    }

    public static string CrearUsuario(int longitud)
    {
        string _allowedChars = "abcdefghijklmnopqrstuvwxyz";
        Byte[] randomBytes = new Byte[longitud];
        char[] chars = new char[longitud];
        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < longitud; i++)
        {
            Random randomObj = new Random();
            randomObj.NextBytes(randomBytes);
            chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
        }
        return new string(chars);
    }

    public static string CreateRandomPassword(int PasswordLenght)
    {
        string _allowedChars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        Byte[] randomBytes = new Byte[PasswordLenght];
        char[] chars = new char[PasswordLenght];
        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < PasswordLenght; i++)
        {
            Random randomObj = new Random();
            randomObj.NextBytes(randomBytes);
            chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
        }
        return new string(chars);
    }

    public static string encriptar(string texto)
    {
        const string sKey = "MonitorContribuciones";

        UTF8Encoding enc = new UTF8Encoding();
        byte[] datos = enc.GetBytes(texto);
        MemoryStream ms = new MemoryStream(datos);
        DESCryptoServiceProvider r = new DESCryptoServiceProvider();
        r.Key = Encoding.Default.GetBytes(sKey.Substring(0, 8));
        r.IV = Encoding.Default.GetBytes(sKey.Substring(0, 8));
        MemoryStream msTMP = new MemoryStream();
        CryptoStream cs = new CryptoStream(msTMP, r.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(datos, 0, datos.Length);
        cs.Close();
        return Convert.ToBase64String(ms.ToArray());
    }
}
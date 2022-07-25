using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Seguridad
{
    public class Encriptar
    {
        public string GetMD5(string texto)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(texto));
            byte[] resultado = MD5.Hash;
            StringBuilder str = new StringBuilder();
            for(int i = 0;i<resultado.Length;i++)
            {
                str.Append(resultado[i].ToString("x2"));
            }
            return str.ToString();
        }

        private static string Key = "asdfqwertuniolnmajeolikoajskidjq";
        private static string IV = "asdfghjklopqwert";

        public string encriptar(string texto)
        {
            byte[] textoplano = System.Text.ASCIIEncoding.ASCII.GetBytes(texto);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encriptar = crypto.TransformFinalBlock(textoplano, 0, textoplano.Length);
            crypto.Dispose();
            return Convert.ToBase64String(encriptar);

        }

        public string Desencriptar(string cifrar_texto)
        {
            byte[] encriptado = Convert.FromBase64String(cifrar_texto);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] des = crypto.TransformFinalBlock(encriptado, 0, encriptado.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(des);
        }
    }
}

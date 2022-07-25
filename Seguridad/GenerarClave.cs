using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Seguridad
{
    public class GenerarClave
    {
        public string GenerarClaveRandom(string nick)
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random R = new Random();
            string randomstring = "";
            for (int i = 0; i < 15; i++)
            {
                randomstring += letters[R.Next(0, 26)].ToString();
            }

            CambiarClave(nick, randomstring);
            GenerarTxt(nick, randomstring);

            return randomstring;
        }

        public void CambiarClave(string nick,string clave)
        {
            SqlConnection Conexion = new SqlConnection(@"Data Source=LAPTOP-3E538O6F;Initial Catalog=TecnoSol;Integrated Security=True");
            Conexion.Open();
            string consulta = "Update Usuario set Contraseña = '" + clave + "' where Nick = '" + nick + "'";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

         void GenerarTxt(string nick, string clave)
        {
            string FileName = @"C:\Users\gonza\Desktop\Clave.txt";
            if(File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            using(FileStream fs = File.Create(FileName))
            {
                byte[] descripcion = new UTF8Encoding(true).GetBytes("Usuario " + nick + " su clave nueva sera: " + clave + " . Por favor, utilicela para generar una nueva clave");
                fs.Write(descripcion, 0, descripcion.Length);
            }
        }

    }
}

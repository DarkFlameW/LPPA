using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Seguridad
{
    public class Digito_Verificador
    {
        DAL.Acceso Acceso = new DAL.Acceso();
        //string Valor;
        //string Nom_tabla;
        //string Consulta;
        long AsciiHorizontal;

        public long ObtenerAscii(string texto)
        {
            long sumaascii = 0;
            if (texto != null)
            {
                int i;
                for (i = 0; i <= texto.Length - 1; i++)
                    sumaascii += Convert.ToInt64((Strings.Asc(texto[i]).ToString()));
            }
            return sumaascii;
        }

        public long DVH(string consulta, string tabla)
        {
            AsciiHorizontal = default(long);
            DataSet ds = new DataSet();
            ds = Acceso.EjecutarConsultaDSTabla(consulta, tabla);

            for (int i = 0; i <= Information.UBound(ds.Tables[0].Rows[0].ItemArray, 1) - 1; i++)
                try
                {
                    AsciiHorizontal += ObtenerAscii((ds.Tables[0].Rows[0].ItemArray[i]).ToString());
                }
                catch (Exception ex)
                {

                }
            return AsciiHorizontal;
        }

       public int SumaDVV(string tabla)
        {
           int i= 0;
           SqlConnection Conexion = new SqlConnection(@"Data Source=LAPTOP-3E538O6F;Initial Catalog=TecnoSol;Integrated Security=True");
            Conexion.Open();
            string consulta = "Select SUM(DV) from "+tabla+"";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader dr = cmd.ExecuteReader();
           if(dr.HasRows)
           {
               dr.Read();
               i = dr.GetInt32(0);
           }

           Conexion.Close();
           return i;
        }

        public void InsertarDVV(string nombre,int suma)
       {
           SqlConnection Conexion = new SqlConnection(@"Data Source=LAPTOP-3E538O6F;Initial Catalog=TecnoSol;Integrated Security=True");
           Conexion.Open();
           string consulta = "Update DVV set DVV.DVV = " + suma + " where DVV.NomTabla = '" + nombre + "'";
           SqlCommand cmd = new SqlCommand(consulta, Conexion);
           cmd.ExecuteNonQuery();
           Conexion.Close();
       }

        public long ObtenerDVV(string nomtabla)
        {
            long i = 0;
            SqlConnection Conexion = new SqlConnection(@"Data Source=LAPTOP-3E538O6F;Initial Catalog=TecnoSol;Integrated Security=True");
            Conexion.Open();
            string consulta = "Select DVV from DVV where NomTabla = '" + nomtabla + "'";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                i = rd.GetInt32(0);
            }
            Conexion.Close();
            return i;
        }
    }
}

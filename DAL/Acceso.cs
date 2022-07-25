using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        public SqlConnection Conexion = new SqlConnection();
        

        #region Abrir/Cerrar conexion

        public void Abrir()
        {
            
            Conexion.ConnectionString = @"Data Source=DESKTOP-F0QUJV3\SQLEXPRESS;Initial Catalog=TecnoSol;Integrated Security=True";
            Conexion.Open();
        }

        public void Cerrar()
        {
            Conexion.Close();
        }

        #endregion
        public DataTable Leer(string St, SqlParameter[] Param)
        {
            Abrir();
            DataTable Tabla = new DataTable();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = new SqlCommand();
            Adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            Adaptador.SelectCommand.CommandText = St;
            Adaptador.SelectCommand.Connection = Conexion;
            if (Param != null)
            {
                Adaptador.SelectCommand.Parameters.AddRange(Param);
            }
            Adaptador.Fill(Tabla);
            Cerrar();
            return Tabla;
        }

        public int Escribir(string St, SqlParameter[] Param)
        {
            int FA = 0;
            Abrir();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conexion;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = St;

            Cmd.Parameters.AddRange(Param);
            try
            {
                FA = Cmd.ExecuteNonQuery();
            }
            catch
            {

                FA = -1;
            }
            Cerrar();
            return FA;
        }


        
        public DataSet EjecutarConsultaDSTabla(string consulta, string tabla)
        {
            DataSet DS = new DataSet();
            SqlCommand Com = new SqlCommand();
            Abrir();
            DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter(consulta, Conexion);
            DA.Fill(DS, tabla);
            Cerrar();
            return DS;
        }

        public string EjecutarConsultaDR2(string consulta, string codigo)
        {
            SqlDataReader DR;
            SqlCommand Com = new SqlCommand();
            Abrir();
            string a;
            Com.Connection = Conexion;
            Com.CommandText = consulta;
            DR = Com.ExecuteReader();
            DR.Read();
            if (DR.HasRows == true)
                a = DR["codigo"].ToString();
            else
                a = (0).ToString();
            DR.Close();
            Cerrar();
            return a;
        }

        public void EjecutarConsultaNonQuery(string consulta)
        {
            Abrir();
            SqlCommand Com = new SqlCommand();
            Com.Connection = Conexion;
            Com.CommandText = consulta;
            Com.ExecuteNonQuery();
            Cerrar();
        }
    }
}

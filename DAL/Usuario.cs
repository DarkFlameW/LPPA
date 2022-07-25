using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Usuario
    {
        Acceso Acceso = new Acceso();

        public int PerfilUsuario(string usuario, string contraseña)
        {
            int p = 0;
            Acceso.Abrir();
            SqlCommand cmd = new SqlCommand("Select Perfil from Usuario where Nick = '" + usuario + "'and Contraseña = '" + contraseña + "'", Acceso.Conexion);
            SqlDataReader lector = cmd.ExecuteReader();
            while(lector.Read())
            {
                p = int.Parse(lector["Perfil"].ToString());
               
            }
            lector.Close();
            Acceso.Cerrar();
            return p;
        }

        public int Verificar(string usuario, string contraseña)
        {
            int validacion = 0;
            Acceso.Abrir();
            SqlCommand cmd = new SqlCommand("Select IdUsuario from Usuario where Nick= '" + usuario + "'and Contraseña = '" + contraseña + "'",Acceso.Conexion);
            SqlDataReader lector = cmd.ExecuteReader();
            while(lector.Read())
            {
                validacion = 1;
            }
            
            lector.Close();
            Acceso.Cerrar();
            return validacion;
        }

        public int VerficarConVieja(string clave)
        {
            int validacion = 0;
            Acceso.Abrir();
            SqlCommand cmd = new SqlCommand("Select IdUsuario from Usuario where Contraseña = '" + clave + "'", Acceso.Conexion);
            SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                validacion = 1;
            }

            lector.Close();
            Acceso.Cerrar();
            return validacion;
        }

        public List<BE.Usuario> ListarRecalculo()
        {
            List<BE.Usuario> Listausu = new List<BE.Usuario>();
            DataTable Tabla = Acceso.Leer("ListarUsuario", null);
            foreach (DataRow Registro in Tabla.Rows)
            {
                BE.Usuario U = new BE.Usuario();
                U.IdUsuario = int.Parse(Registro["IdUsuario"].ToString());
                U.Nombre = Registro["Nombre"].ToString();
                U.Apellido = Registro["Apellido"].ToString();
                U.Nick = Registro["Nick"].ToString();
                U.Contraseña = Registro["Contraseña"].ToString();
                U.Mail = Registro["Mail"].ToString();
                U.Intentos = Registro["Intentos"].ToString();
                U.Perfil = int.Parse(Registro["Perfil"].ToString());
                U.Dvh = Registro["DV"].ToString();
                Listausu.Add(U);
            }
            return Listausu;
        }

        public void Consultar(string query)
        {
            Acceso.EjecutarConsultaNonQuery(query);
        }

    }
}

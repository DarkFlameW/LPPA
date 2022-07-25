using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Bitacora
    {
        Acceso Acceso = new Acceso();
        public int CargarBitacora(BE.Bitacora Bitacora)
        {
            int fa = 0;
            SqlParameter[] Param = new SqlParameter[4];
            Param[0] = new SqlParameter("@NickUsuario", Bitacora.NickUsuario);
            Param[1] = new SqlParameter("@Fecha", Bitacora.Fecha);
            Param[2] = new SqlParameter("@Descripcion", Bitacora.Descripcion);
            Param[3] = new SqlParameter("@Criticidad", Bitacora.Criticidad);
            fa = Acceso.Escribir("InsertarBitacora", Param);
            return fa;
        }

        public List<BE.Bitacora>Listar()
        {
            List<BE.Bitacora> Lista = new List<BE.Bitacora>();
            DataTable Tabla = Acceso.Leer("ListarBitacora", null);
            foreach(DataRow Registro in Tabla.Rows)
            {
                BE.Bitacora Bit = new BE.Bitacora();
                Bit.NickUsuario = Registro["NickUsuario"].ToString();
                Bit.Descripcion = Registro["Descripcion"].ToString();
                Bit.Fecha = DateTime.Parse(Registro["Fecha"].ToString());
                Bit.Criticidad = Registro["Criticidad"].ToString();
                Lista.Add(Bit);
            }
            return Lista;
        }

        public DataTable FiltrarFecha(DateTime desde,DateTime hasta)
        {
            Acceso.Abrir();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select NickUsuario,Descripcion,Fecha,Criticidad From Bitacora where Fecha between '" + desde + "' and '" + hasta + "' ", Acceso.Conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Acceso.Cerrar();
            return dt;
        }


    }
}

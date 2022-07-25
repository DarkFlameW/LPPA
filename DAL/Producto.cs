using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Producto
    {
        Acceso Acceso = new Acceso();

        public int CargarProducto(BE.Producto Producto)
        {
            int fa = 0;
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@CodProd", Producto.CodigoProd);
            Param[1] = new SqlParameter("@Nombre", Producto.NombreProd);
            Param[2] = new SqlParameter("@Imagen", Producto.ImagenProd);
            Param[3] = new SqlParameter("@Precio", float.Parse(Producto.PrecioProd));
            Param[4] = new SqlParameter("@Categoria", Producto.CategoriaProd);
            Param[5] = new SqlParameter("@DV", int.Parse(Producto.DV));
            fa = Acceso.Escribir("AltaArticulo", Param);

            return fa;
        }
        //Agrege Baja y modificar 13-7. El parseo esta porque en la bd guarde cantidad y precio como int
        //y float respectivamente
        public int ModificarProducto(BE.Producto Producto)
        {
            int fa = 0;
            SqlParameter[] Param = new SqlParameter[6];
            Param[0] = new SqlParameter("@Nombre", Producto.NombreProd);
            Param[1] = new SqlParameter("@Imagen", Producto.ImagenProd);
            Param[2] = new SqlParameter("@Precio", float.Parse(Producto.PrecioProd));
            Param[3] = new SqlParameter("@Categoria", Producto.CategoriaProd);
            Param[4] = new SqlParameter("@DV", int.Parse(Producto.DV));
            Param[5] = new SqlParameter("@CodProd", Producto.CodigoProd);
            fa = Acceso.Escribir("ModificarArticulo", Param);
            return fa;
        }

        public int BajaProducto(BE.Producto Producto)
        {
            int fa = 0;
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@CodProd", Producto.CodigoProd);
            fa = Acceso.Escribir("BajaArticulo", Param);
            return fa;
        }

        public List<BE.Producto> Listar()
        {
            List<BE.Producto> ListaProd = new List<BE.Producto>();
            DataTable Tabla = Acceso.Leer("ListarProducto", null);
            foreach(DataRow Registro in Tabla.Rows)
            {
                BE.Producto P = new BE.Producto();
                P.NombreProd = Registro["Nombre"].ToString();
                P.PrecioProd = Registro["Precio"].ToString();
                ListaProd.Add(P);
            }
            return ListaProd;
        }

        public List<BE.Producto> ListarRecalculo()
        {
            List<BE.Producto> ListaProd = new List<BE.Producto>();
            DataTable Tabla = Acceso.Leer("ListarProductoRecalculo", null);
            foreach (DataRow Registro in Tabla.Rows)
            {
                BE.Producto P = new BE.Producto();
                P.CodigoProd = Registro["CodProd"].ToString();
                P.NombreProd = Registro["Nombre"].ToString();
                P.ImagenProd = Registro["Imagen"].ToString();
                P.PrecioProd = Registro["Precio"].ToString();
                P.CategoriaProd = Registro["Categoria"].ToString();
                P.DV = Registro["DV"].ToString();
                ListaProd.Add(P);
            }
            return ListaProd;
        }

        public void Consultar(string query)
        {
            Acceso.EjecutarConsultaNonQuery(query);
        }

    }
}

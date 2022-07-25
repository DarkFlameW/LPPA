using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Producto
    {
        DAL.Producto Mapper = new DAL.Producto();

        public int InsertarProducto(BE.Producto Prod)
        {
            return Mapper.CargarProducto(Prod);
        }

        public List<BE.Producto> Listar()
        {
            List<BE.Producto> Lista = Mapper.Listar();
            return Lista;
        }

        public List<BE.Producto> ListarRecalculado()
        {
            List<BE.Producto> Lista = Mapper.ListarRecalculo();
            return Lista;
        }
        //Agregado 13-7 tomi
        public int ModificarProducto(BE.Producto Prod)
        {
            return Mapper.ModificarProducto(Prod);
        }

        public int BajaProducto(BE.Producto Prod)
        {
            return Mapper.BajaProducto(Prod);
        }

        public void Consultar(string query)
        {
            Mapper.Consultar(query);
        }
    }
}

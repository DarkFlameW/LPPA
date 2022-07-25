using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Bitacora
    {
        DAL.Bitacora Mapper = new DAL.Bitacora();

        public int InsertarBitacora(BE.Bitacora Bt)
        {
            return Mapper.CargarBitacora(Bt);
        }
        public List<BE.Bitacora> Listar()
        {
            List<BE.Bitacora> Lista = Mapper.Listar();
            return Lista;
        }

        public DataTable FiltrarFecha(DateTime desde, DateTime hasta)
        {
            return Mapper.FiltrarFecha(desde, hasta);
        }
    }
}

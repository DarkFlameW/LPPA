using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto
    {
        private string _Codigo;

        public string CodigoProd
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private string _Nombre;

        public string NombreProd
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        

        private string _Imagen;

        public string ImagenProd
        {
            get { return _Imagen; }
            set { _Imagen = value; }

        }

        private string _Precio;

        public string PrecioProd
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        private string _Categoria;

        public string CategoriaProd
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        private string _dv;

        public string DV
        {
            get { return _dv; }
            set { _dv = value; }
        }


    }
}

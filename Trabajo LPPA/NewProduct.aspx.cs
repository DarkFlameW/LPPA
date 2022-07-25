using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Trabajo_LPPA
{
    public partial class NewProduct : System.Web.UI.Page
    {
        BLL.Producto GestorProducto = new BLL.Producto();
        BE.Producto ProductoTemp;
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        BE.Bitacora BitacoraTemp;
        long dv;
        Seguridad.Digito_Verificador DV = new Seguridad.Digito_Verificador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["Perfil"].ToString()) != 1)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }
        
        //Agregue metodos para luego ser utilizados en los botones que se agreguen tanto aqui como en otro formulario. 13-7
        public void CargarProductos()
        {
            string imagennombre;
            string extension;
            
            ProductoTemp = new BE.Producto();
            if(Imagen.HasFile==true)
            { 
                ProductoTemp.CodigoProd = TxtCodigo.Text;
                ProductoTemp.NombreProd = TxtNombre.Text;
                
                imagennombre = Path.GetFileNameWithoutExtension(Imagen.FileName);
                extension = Path.GetExtension(Imagen.FileName);
                ProductoTemp.ImagenProd = imagennombre + extension;
                ProductoTemp.PrecioProd = TxtPrecio.Text;
                ProductoTemp.CategoriaProd = TxtCategoria.Text;
                ProductoTemp.DV = 0.ToString();
                try
                {
                    GestorProducto.InsertarProducto(ProductoTemp);
                    ProductoTemp = null;

                    dv = DV.DVH("select * from Producto where CodProd =" + TxtCodigo.Text + "", "Producto");
                    GestorProducto.Consultar("update Producto set DV=" + dv + " where CodProd =" + TxtCodigo.Text + "");
                    DV.InsertarDVV("Producto", DV.SumaDVV("Producto"));
                    TxtCategoria.Text = "";
                    TxtCodigo.Text = "";
                    TxtNombre.Text = "";
                    TxtPrecio.Text = "";
                    CargarBitacora(Session["Nick"].ToString(), "Nuevo Producto Añadido", "Baja");
                }
                catch (Exception)
                {
                    
                    throw;
                }

                
            }
        }

        void CargarBitacora(string Nick, string Descripcion, string Criticidad)
        {
            BitacoraTemp = new BE.Bitacora();

            BitacoraTemp.NickUsuario = Nick;
            BitacoraTemp.Fecha = DateTime.Now;
            BitacoraTemp.Descripcion = Descripcion;
            BitacoraTemp.Criticidad = Criticidad;

            GestorBitacora.InsertarBitacora(BitacoraTemp);
        }

        
    }
}
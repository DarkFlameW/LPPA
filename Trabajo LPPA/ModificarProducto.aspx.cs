using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace Trabajo_LPPA
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
        BE.Producto ProductoTemp;
        BLL.Producto producto = new BLL.Producto();
        Seguridad.Digito_Verificador DV = new Seguridad.Digito_Verificador();
        long dv;
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        BE.Bitacora BitacoraTemp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["Perfil"].ToString()) == 1)
            {
                TxtCodigo.Enabled = false;
                TxtNombre.Enabled = false;
                TxtCategoria.Enabled = false;
                TxtImagen.Enabled = false;
                enlazar();
            }
            else if (int.Parse(Session["Perfil"].ToString()) != 1)
            {
                Response.Redirect("LogIn.aspx");
            }
            
        }

        public void enlazar()
        {
            GridView1.DataSource = null;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        public void Modificar()
        {
            ProductoTemp = new BE.Producto();

            ProductoTemp.CodigoProd = TxtCodigo.Text;
            ProductoTemp.NombreProd = TxtNombre.Text;
            ProductoTemp.ImagenProd = TxtImagen.Text;
            ProductoTemp.PrecioProd = TxtPrecio.Text;
            ProductoTemp.DV = 0.ToString();
            ProductoTemp.CategoriaProd = TxtCategoria.Text;
            try
            {
                producto.ModificarProducto(ProductoTemp);
                    ProductoTemp = null;
                    enlazar();

                    dv = DV.DVH("select * from Producto where CodProd =" + TxtCodigo.Text + "", "Producto");
                    producto.Consultar("update Producto set DV=" + dv + " where CodProd =" + TxtCodigo.Text + "");
                    DV.InsertarDVV("Producto", DV.SumaDVV("Producto"));
                    TxtCategoria.Text = "";
                    TxtCodigo.Text = "";
                    TxtNombre.Text = "";
                    TxtPrecio.Text = "";
                    CargarBitacora(Session["Nick"].ToString(), "Producto Modificado", "Baja");
            }
            catch (Exception)
            {
                
                throw;
            }

           // producto.ModificarProducto(ProductoTemp);
           // enlazar();

            //ProductoTemp = null;
           
            
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="Editar")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                TxtCodigo.Text = GridView1.Rows[crow].Cells[0].Text;
                TxtNombre.Text = GridView1.Rows[crow].Cells[1].Text;
                TxtImagen.Text = GridView1.Rows[crow].Cells[2].Text;
                TxtPrecio.Text = GridView1.Rows[crow].Cells[3].Text;
                TxtCategoria.Text = GridView1.Rows[crow].Cells[4].Text;
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
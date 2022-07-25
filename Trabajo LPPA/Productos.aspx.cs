using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Trabajo_LPPA
{
    public partial class Productos : System.Web.UI.Page
    {
        BLL.Producto Prod = new BLL.Producto();
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        BE.Bitacora BitacoraTemp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["Perfil"].ToString()) == 3)
            {
                Listar();
            }
            else if (int.Parse(Session["Perfil"].ToString()) != 3)
            {
                Response.Redirect("LogIn.aspx");
            }
            
        }

        public void Listar()
        {
            List<BE.Producto> ListaProd = Prod.Listar();
            DataTable DT = new DataTable();
            DT.Columns.AddRange(new DataColumn[2] { new DataColumn("Nombre"),  new DataColumn("Precio") });
            foreach (BE.Producto P in ListaProd)
            {
                DataRow Row = DT.NewRow();
                Row[0] = P.NombreProd;
                Row[1] = P.PrecioProd;
                DT.Rows.Add(Row);
            }
            GridView1.DataSource = DT;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")
                {
                    int RowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow Row = GridView1.Rows[RowIndex];
                    AgregarCarrito(Row);
                    CargarBitacora(Session["Nick"].ToString(), "Producto Agregado al Carrito", "Baja");

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        void AgregarCarrito(GridViewRow Row)
        {
            string Nom = Row.Cells[0].Text;
            float Pre = float.Parse(Row.Cells[1].Text);

            List<BE.Producto> Carrito = (List<BE.Producto>)this.Session["carrito"];
            if (Carrito == null)
            {
                Carrito = new List<BE.Producto>();
            }
            BE.Producto NuevoProducto = new BE.Producto()
            {
                NombreProd = Nom,
                PrecioProd = Pre.ToString()
            };
            Carrito.Add(NuevoProducto);
            this.Session["carrito"] = Carrito;
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
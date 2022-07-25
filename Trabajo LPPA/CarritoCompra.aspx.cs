using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Trabajo_LPPA
{
    public partial class CarritoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["Perfil"].ToString()) == 3)
            {
                List<BE.Producto> CarritoFinal = (List<BE.Producto>)this.Session["carrito"];
                this.listaProductos.DataBind();
                ListadoCarrito(CarritoFinal);
            }
            else if (int.Parse(Session["Perfil"].ToString()) != 3)
            {
                Response.Redirect("LogIn.aspx");
            }
           

        }

        public void ListadoCarrito(List<BE.Producto> LP)
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(new DataColumn("Nombre", typeof(string)));
            DT.Columns.Add(new DataColumn("Precio", typeof(string)));
            float total = 0;
            if (LP != null)
            {
                foreach (BE.Producto prod in LP)
                {
                    DataRow row = DT.NewRow();

                    row[0] = prod.NombreProd;
                    row[1] = prod.PrecioProd;
                    total += float.Parse(prod.PrecioProd);
                    DT.Rows.Add(row);
                }
            }
            DataRow finalRow = DT.NewRow();
            finalRow[0] = "TOTAL";
            finalRow[1] = total;
            DT.Rows.Add(finalRow);

            this.listaProductos.DataSource = DT;
            this.listaProductos.DataBind();
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            List<BE.Producto> carrito = (List<BE.Producto>)this.Session["carrito"];

            if (carrito == null || carrito.Count < 1)
            {
                Response.Write("No tienes productos en el carrito");
                return;
            }
            BLL.Bitacora bit = new BLL.Bitacora();
            BE.Bitacora bitnew = new BE.Bitacora();
            bitnew.NickUsuario = "MartinPerei";

            bitnew.Fecha = DateTime.Now;
            bitnew.Descripcion = "Compra realizada";
            bitnew.Criticidad = "Baja";
            bit.InsertarBitacora(bitnew);
            this.listaProductos.DataSource = null;
            this.listaProductos.DataBind();
            this.Session["carrito"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Compra realizada con exito');</script>");
        }
    }
}
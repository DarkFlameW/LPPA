using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_LPPA
{
    public partial class Webmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (int.Parse(Session["Perfil"].ToString()) != 2)
            {
                Response.Redirect("LogIn.aspx");
            }
             else
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + Session["ErrorTablaProducto"] + ", " + Session["RegistroProducto"] + ", "+Session["ErrorTablaUsuario"]+","+Session["RegistroUsuario"]+" ');</script>");
             }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_LPPA
{
    public partial class Bitacora : System.Web.UI.Page
    {
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(int.Parse(Session["Perfil"].ToString())==2)
            {
                GridView1.DataSource = null;
                GridView1.DataSource = GestorBitacora.Listar();
                GridView1.DataBind();
            }
            else if(int.Parse(Session["Perfil"].ToString()) != 2)
             {
                 Response.Redirect("LogIn.aspx");
             }
        }
    }
}


      
          
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_LPPA
{
    public partial class Admin2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["Perfil"].ToString()) != 1)
            {
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}
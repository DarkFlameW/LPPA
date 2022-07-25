using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seguridad;
namespace Trabajo_LPPA
{
    public partial class Backup : System.Web.UI.Page
    {
        Backup_y_Restore backup = new Backup_y_Restore();
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        BE.Bitacora BitacoraTemp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["Perfil"].ToString()) != 2)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Session["Error"].ToString()=="Si")
            {
                Button1.Enabled = false;
            }
            else
            {
                backup.GenerarBackUp();
                CargarBitacora(Session["Nick"].ToString(), "BackupRealizado", "Baja");
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
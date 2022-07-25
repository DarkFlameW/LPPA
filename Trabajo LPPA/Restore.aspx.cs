using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Seguridad;
namespace Trabajo_LPPA
{
    public partial class Restore : System.Web.UI.Page
    {
        Backup_y_Restore restore = new Backup_y_Restore();
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        BE.Bitacora BitacoraTemp;
        string nombresillo;
        string extension;
        string final;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (int.Parse(Session["Perfil"].ToString()) != 2)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string direccion = "C:/Users/gonza/Desktop/backups";
            
            if(FileUpload1.HasFile==true)
            {
                
              nombresillo = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
              //string direccion1 = direccion + nombresillo;
              extension = Path.GetExtension(FileUpload1.FileName);

              final = nombresillo + extension;
            }
           // Label1.Text = ;
            restore.GenerarRestore(final);
            CargarBitacora(Session["Nick"].ToString(), "Restore Realizado", "Alta");
            Session["ErrorTablaProducto"] ="";
            Session["RegistroProducto"] ="";
            Session["ErrorTablaUsuario"]="";
            Session["RegistroUsuario"] = "";
            Session["Error"] = 0;
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
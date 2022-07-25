using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
 using System.Text.RegularExpressions;
namespace Trabajo_LPPA
{

    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        BLL.Usuario GestorUsuario = new BLL.Usuario();
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        BE.Bitacora BitacoraTemp;
        int verificar = 0;
        Seguridad.Encriptar Encr = new Seguridad.Encriptar();
        Seguridad.GenerarClave GC = new Seguridad.GenerarClave();
        Seguridad.Digito_Verificador Dv = new Seguridad.Digito_Verificador();
        long dv = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Para cambiar la clave, abra el archivo generado en su escritorio');</script>");
        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string maildescifrado;
            maildescifrado = Encr.Desencriptar(TraerMail(Session["Nick"].ToString()));
            if (ExpresionRegular() == true)
            {
                if (TxtMail.Text == maildescifrado)
                {
                    verificar = GestorUsuario.VerificarConVieja(TxtContraseñaGenerada.Text);
                    if (verificar == 1)
                    {
                        string connueva;

                        connueva = Encr.GetMD5(TxtContraseñaNueva.Text);
                        GC.CambiarClave(Session["Nick"].ToString(), connueva);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Contraseña cambiada correctamente');</script>");

                        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-3E538O6F;Initial Catalog=TecnoSol;Integrated Security=True");
                        Con.Open();
                        string consulta = "Update Usuario set Contraseña = '" + connueva + "',Intentos = 0 where Mail = '" + TxtMail.Text + "'";
                        SqlCommand cmd = new SqlCommand(consulta, Con);
                        cmd.ExecuteNonQuery();
                        Con.Close();
                        EliminarTxt();
                        dv = Dv.DVH("select * from Usuario where Nick ='" + Session["Nick"].ToString() + "'", "Usuario");
                        GestorUsuario.Consultar("update Usuario set DV='" + dv + "' where Nick ='" + Session["Nick"].ToString() + "'");
                        Dv.InsertarDVV("Usuario", Dv.SumaDVV("Usuario"));
                        CargarBitacora(Session["Nick"].ToString(), "Contraseña Modificada", "Media");
                        Response.Redirect("LogIn.aspx");
                    }
                    else if (verificar != 1)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Datos mal ingresados, intente nuevamente');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Mail mal ingresado');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Mail mal ingresado');</script>");
            }

        }
        void EliminarTxt()
        {
            string FileName = @"C:\Users\gonza\Desktop\Clave.txt";
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
        }

        public string TraerMail(string nick)
        {
            string mail = "";
            SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-3E538O6F;Initial Catalog=TecnoSol;Integrated Security=True");
            Con.Open();
            string consulta = "Select Mail from Usuario where Nick = '" + nick + "'";
            SqlCommand cmd = new SqlCommand(consulta, Con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                mail = rd.GetString(0);
            }
            Con.Close();
            return mail;
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



        public Boolean ExpresionRegular()
        {
            Boolean Bool;
            Regex Reg = new Regex("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", RegexOptions.IgnoreCase);
            if (Reg.IsMatch(TxtMail.Text))
            {
                Bool = true;
            }
            else
            {
                Bool = false;
            }
            return Bool;
        }


    }        
}
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
    public partial class LogIn : System.Web.UI.Page
    {
        BLL.Usuario GestorUsuario = new BLL.Usuario();
        BLL.Bitacora GestorBitacora = new BLL.Bitacora();
        BE.Usuario UsTemp;
        BE.Bitacora BitacoraTemp;
        Seguridad.Encriptar Encriptacion = new Seguridad.Encriptar();
        Seguridad.GenerarClave GC = new Seguridad.GenerarClave();
        Seguridad.Digito_Verificador Dv = new Seguridad.Digito_Verificador();
        long dv=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Perfil"] = 0;
            Session["Nick"] = null;

            if (Session["Error"].ToString() == "Si")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error');</script>");
                UpdateWebMaster();
                CargarBitacora("-", "Error Digitos Verificadores", "Alta");
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

        void Loguearse()
        {
            UsTemp = new BE.Usuario();
            UsTemp.Nick = TxtNick.Text;
            UsTemp.Contraseña = Encriptacion.GetMD5(TxtContraseña.Text);
            Session["Nick"] = UsTemp.Nick;
            Session["Perfil"] = GestorUsuario.PerfilUsuario(UsTemp.Nick, UsTemp.Contraseña);
            Session["Intentos"] = Intentos(Session["Nick"].ToString());

            if (Session["Error"].ToString() == "Si")
            {
                if (Convert.ToInt32(Session["Intentos"]) < 3)
                {
                    if (GestorUsuario.Verificar(UsTemp.Nick, UsTemp.Contraseña) == 1)
                    {
                        CargarBitacora(Session["Nick"].ToString(), "Inicio sesion", "Baja");
                        ReiniciarIntentos(Session["Nick"].ToString());

                        if (int.Parse(Session["Perfil"].ToString()) == 2)
                        {
                            Response.Redirect("Webmaster.aspx");
                        }
                    }
                    else if (GestorUsuario.Verificar(UsTemp.Nick, UsTemp.Contraseña) == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Datos mal cargados');</script>");
                        SumaIntentos(Session["Nick"].ToString());
                        dv = Dv.DVH("select * from Usuario where Nick ='" + Session["Nick"] + "'", "Usuario");
                        GestorUsuario.Consultar("update Usuario set DV='" + dv + "' where Nick ='" + Session["Nick"] + "'");
                        Dv.InsertarDVV("Usuario", Dv.SumaDVV("Usuario"));
                        CargarBitacora(Session["Nick"].ToString(), "Datos Incorrectos", "Media");
                    }
                }
                else if (Convert.ToInt32(Session["Intentos"]) == 3)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se ha bloqueado su usuario, contactese con el administrador');</script>");
                    CargarBitacora(Session["Nick"].ToString(), "Usuario BLOQUEADO", "Medio");
                }
            }
            else
            {
                if (Convert.ToInt32(Session["Intentos"]) < 3)
                {
                    if (GestorUsuario.Verificar(UsTemp.Nick, UsTemp.Contraseña) == 1)
                    {
                        CargarBitacora(Session["Nick"].ToString(), "Inicio sesion", "Baja");
                        ReiniciarIntentos(Session["Nick"].ToString());

                        if (int.Parse(Session["Perfil"].ToString()) == 1)
                        {
                            Response.Redirect("Admin2.aspx");
                        }
                        else if (int.Parse(Session["Perfil"].ToString()) == 2)
                        {
                            Response.Redirect("Webmaster.aspx");
                        }
                        else if (int.Parse(Session["Perfil"].ToString()) == 3)
                        {
                            Response.Redirect("VentanaCliente.aspx");
                        }
                    }
                    else if (GestorUsuario.Verificar(UsTemp.Nick, UsTemp.Contraseña) == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Datos mal cargados');</script>");
                        SumaIntentos(Session["Nick"].ToString());
                        dv = Dv.DVH("select * from Usuario where Nick ='" + Session["Nick"] + "'", "Usuario");
                        GestorUsuario.Consultar("update Usuario set DV='" + dv + "' where Nick ='" + Session["Nick"] + "'");
                        Dv.InsertarDVV("Usuario", Dv.SumaDVV("Usuario"));
                        CargarBitacora(Session["Nick"].ToString(), "Datos Incorrectos", "Media");
                    }
                }
                else if (Convert.ToInt32(Session["Intentos"]) == 3)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se ha bloqueado su usuario, contactese con el administrador');</script>");
                    CargarBitacora(Session["Nick"].ToString(), "Usuario BLOQUEADO", "Medio");
                }
            }
        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            Loguearse();
        }

        

        protected void LinkButtonRecuperar_Click(object sender, EventArgs e)
        {
            Session["Nick"] = TxtNick.Text;
            
            if(QueryVerificarExistencia(Session["Nick"].ToString())==1)
            {
                GC.GenerarClaveRandom(Session["Nick"].ToString());
                Response.Redirect("RecuperarContraseña.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ingresado un usuario incorrecto');</script>");
            }
        }

        int QueryVerificarExistencia(string nick)
        {
            int verificar = 0;
            SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-F0QUJV3\SQLEXPRESS;Initial Catalog=TecnoSol;Integrated Security=True");
            Con.Open();
            string consulta = "Select IdUsuario from Usuario where Nick = '" + nick + "'";
            SqlCommand cmd = new SqlCommand(consulta, Con);
            SqlDataReader lector = cmd.ExecuteReader();
            while(lector.Read())
            {
                verificar = 1;
            }
            lector.Close();
            Con.Close();
            return verificar;
        }
        public int Intentos(string nick)
        {
            int i = 0;
            SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-F0QUJV3\SQLEXPRESS;Initial Catalog=TecnoSol;Integrated Security=True");
            Conexion.Open();
            string consulta = "Select Intentos from Usuario where Nick='" + nick + "'";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                i = rd.GetInt32(0);
            }
            Conexion.Close();
            return i;
        }

        public void SumaIntentos(string nick)
        {
            SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-F0QUJV3\SQLEXPRESS;Initial Catalog=TecnoSol;Integrated Security=True");
            Conexion.Open();
            string consulta = "Update Usuario set Intentos += 1 where Nick = '" + nick + "'";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void ReiniciarIntentos(string nick)
        {
            SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-F0QUJV3\SQLEXPRESS;Initial Catalog=TecnoSol;Integrated Security=True");
            Conexion.Open();
            string consulta = "Update Usuario set Intentos = 0 where Nick = '" + nick + "'";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        public void UpdateWebMaster()
        {
            SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-F0QUJV3\SQLEXPRESS;Initial Catalog=TecnoSol;Integrated Security=True");
            Conexion.Open();
            string consulta = "Update Usuario set Nombre = 'Agustin',Apellido = 'Martinez',Contraseña='08345ebdf7f1d961d5f07398d3e8b24d',Mail='28Qk5WAfiiQKtfTANzh0GvmhAKWI4IZQj8YiJ6hr+fM=',Perfil=2 where IdUsuario= 2";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            cmd.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}
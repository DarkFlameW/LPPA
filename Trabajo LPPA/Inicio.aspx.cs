using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_LPPA
{
    public partial class Inicio : System.Web.UI.Page
    {
        BLL.Producto GestorProducto = new BLL.Producto();
        BLL.Usuario GestorUsuario = new BLL.Usuario();
       // Seguridad.Digito_Verificador DV = new Seguridad.Digito_Verificador();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Perfil"] = 0;
            Session["Error"] = "";
           // VerificarConsistenciaProducto();
            //MostrarFilaRotaProducto();
           // VerificarConsistenciaUsuario();
           // MostrarFilaUsuario();
        }

    /*   void VerificarConsistenciaProducto()
        {
            long dvh = 0;
            long suma = 0;

            List<BE.Producto> Prod = GestorProducto.ListarRecalculado();
            foreach (BE.Producto prod in Prod.ToList())
            {
                string cod = prod.CodigoProd;
                string nombre = prod.NombreProd;
                string precio = prod.PrecioProd;
                string categoria = prod.CategoriaProd;
                string imagen = prod.ImagenProd;

                long codigo = DV.ObtenerAscii(cod);
                long nombres = DV.ObtenerAscii(nombre);
                long precios = DV.ObtenerAscii(precio);
                long categorias = DV.ObtenerAscii(categoria);
                long imagenes = DV.ObtenerAscii(imagen);

                suma = codigo + nombres + precios + categorias + imagenes;
                dvh += suma;
            }
            if (dvh != DV.ObtenerDVV("Producto"))
            {
                Session["ErrorTablaProducto"] = "Hay un error con los digitos en la tabla de producto";
                Session["Error"] = "Si";
            }
        }*/

     /*   void MostrarFilaRotaProducto()
        {
            long suma = 0;
            List<string> CamposFallidos = new List<string>();
            List<BE.Producto> Prod2 = GestorProducto.ListarRecalculado();
            foreach (BE.Producto prod in Prod2.ToList())
            {
                string cod = prod.CodigoProd;
                string nombre = prod.NombreProd;
                string precio = prod.PrecioProd;
                string categoria = prod.CategoriaProd;
                string imagen = prod.ImagenProd;
                string dv = prod.DV;

                long codigo = DV.ObtenerAscii(cod);
                long nombres = DV.ObtenerAscii(nombre);
                long precios = DV.ObtenerAscii(precio);
                long categorias = DV.ObtenerAscii(categoria);
                long imagenes = DV.ObtenerAscii(imagen);
                long dvlong = long.Parse(dv);

                suma = codigo + nombres + precios + categorias + imagenes;
                if (dvlong == suma)
                {
                    Prod2.Remove(prod);
                }
            }
            foreach (BE.Producto MalCampo in Prod2)
            {
                CamposFallidos.Add(crearMensajeError(MalCampo));
            }

            string msj = "";

            if (CamposFallidos.Count > 0)
            {
                msj += string.Join(",", CamposFallidos);

                Session["RegistroProducto"] = msj;
                Session["Error"] = "Si";
            }

        }*/
        //Consistencia de Usuario
      /*  void VerificarConsistenciaUsuario()
        {
            long dvh = 0;
            long suma = 0;

            List<BE.Usuario> Prod = GestorUsuario.ListarRecalculado();
            foreach (BE.Usuario prod in Prod.ToList())
            {
                string id = prod.IdUsuario.ToString();
                string nombre = prod.Nombre;
                string apellido = prod.Apellido;
                string nick = prod.Nick;
                string contraseña = prod.Contraseña;
                string mail = prod.Mail;
                string intentos = prod.Intentos;
                string perfil = prod.Perfil.ToString();
                

                long idl = DV.ObtenerAscii(id);
                long nombres= DV.ObtenerAscii(nombre);
                long apellidos = DV.ObtenerAscii(apellido);
                long nicks = DV.ObtenerAscii(nick);
                long contraseñas = DV.ObtenerAscii(contraseña);
                long mails = DV.ObtenerAscii(mail);
                long intento = DV.ObtenerAscii(intentos);
                long perfiles = DV.ObtenerAscii(perfil);
                suma = idl + nombres + apellidos + nicks + contraseñas + mails + intento + perfiles;
                dvh += suma;
            }
            if (dvh != DV.ObtenerDVV("Usuario"))
            {
                Session["ErrorTablaUsuario"] = "Hay un error con los digitos en la tabla de Usuario";
                Session["Error"] = "Si";
            }
        }*/

    /*    void MostrarFilaUsuario()
        {
            
            long suma = 0;
            List<string> CamposFallidosUsu = new List<string>();
            List<BE.Usuario> Prods = GestorUsuario.ListarRecalculado();
            foreach (BE.Usuario prod in Prods.ToList())
            {
                string id = prod.IdUsuario.ToString();
                string nombre = prod.Nombre;
                string apellido = prod.Apellido;
                string nick = prod.Nick;
                string contraseña = prod.Contraseña;
                string mail = prod.Mail;
                string intentos = prod.Intentos;
                string perfil = prod.Perfil.ToString();
                string dv = prod.Dvh;

                long idl = DV.ObtenerAscii(id);
                long nombres = DV.ObtenerAscii(nombre);
                long apellidos = DV.ObtenerAscii(apellido);
                long nicks = DV.ObtenerAscii(nick);
                long contraseñas = DV.ObtenerAscii(contraseña);
                long mails = DV.ObtenerAscii(mail);
                long intento = DV.ObtenerAscii(intentos);
                long perfiles = DV.ObtenerAscii(perfil);
                long digito = long.Parse(dv);
                suma = idl + nombres + apellidos + nicks + contraseñas + mails + intento + perfiles;
                if (digito == suma)
                {
                    Prods.Remove(prod);
                }
            }
            foreach (BE.Usuario MalCampo in Prods)
            {
                CamposFallidosUsu.Add(crearMensajeErrorUsu(MalCampo));
            }

            string msj = "";

            if (CamposFallidosUsu.Count > 0)
            {
                msj += string.Join(",", CamposFallidosUsu);

                Session["RegistroUsuario"] = msj;
                Session["Error"] = "Si";
            }
            
        }*/

        private string crearMensajeError(BE.Producto prod)
        {
            return "Tabla PRODUCTO, registro con ID: " + prod.CodigoProd + " ha sido modificado";
        }

        private string crearMensajeErrorUsu(BE.Usuario prod)
        {
            return "Tabla USUARIO, registro con ID: " + prod.IdUsuario + " ha sido modificado";
        }
    }
}
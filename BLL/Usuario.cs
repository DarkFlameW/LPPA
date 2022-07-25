using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {
        DAL.Usuario Mapper = new DAL.Usuario();

        public int PerfilUsuario(string nick, string contraseña)
        {
            return Mapper.PerfilUsuario(nick, contraseña);
        }

        public int Verificar(string nick, string contraseña)
        {
            return Mapper.Verificar(nick, contraseña);
        }

        public List<BE.Usuario> ListarRecalculado()
        {
            List<BE.Usuario> Lista = Mapper.ListarRecalculo();
            return Lista;
        }

        public int VerificarConVieja(string clave)
        {
            return Mapper.VerficarConVieja(clave);
        }

        public void Consultar(string query)
        {
            Mapper.Consultar(query);
        }
    }
}

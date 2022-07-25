using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        
        private int _id;

        public int IdUsuario
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nom;

        public string Nombre
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _app;

        public string Apellido
        {
            get { return _app; }
            set { _app = value; }
        }

        private string _nick;

        public string Nick
        {
            get { return _nick; }
            set { _nick = value; }
        }
        private string _cont;

        public string Contraseña
        {
            get { return _cont; }
            set { _cont = value; }
        }

        private int _perf;

        public int Perfil
        {
            get { return _perf; }
            set { _perf = value; }
        }

        private string dvh;

        public string Dvh
        {
            get { return dvh; }
            set { dvh = value; }
        }

        private string intentos;

        public string Intentos
        {
            get { return intentos; }
            set { intentos = value; }
        }
        
        
    }
}

using CineNet.Models;
using CineHandler;

namespace AgenciaMedica.Models.Core
{
    internal class CoreUsuario
    {
        private string user;
        private string password;

        public CoreUsuario(string user, string password)
        {
            this.user = user;
            this.password = password;
        }

        public Usuario ValidarYObtenerUsuario()
        {
            //FactoryUsuario nuevoUsuario = new FactoryUsuario();
            Usuario nuevo = new Usuario(user, password);// nuevoUsuario.GetUsuario(user, password);
            //Usuario nuevo = CineHandler.
            return nuevo;
        }

        public Usuario RegistrarNuevoUsuario(string user, string mail, string password)
        {
            Usuario nuevoUsuario = new Usuario(user, password);
            return nuevoUsuario;
        }
    }
}
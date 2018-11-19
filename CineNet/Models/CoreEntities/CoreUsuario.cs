using CineNet.Models;

namespace AgenciaMedica.Models.Core
{
    internal static class CoreUsuario
    {
        public static Usuario ValidarYObtenerUsuario(string user, string password)
        {
            //FactoryUsuario nuevoUsuario = new FactoryUsuario();
            Usuario nuevo = new Usuario(user, password);// nuevoUsuario.GetUsuario(user, password);
            return nuevo;
        }

        public static Usuario RegistrarNuevoUsuario(string user, string mail, string password)
        {
            Usuario nuevoUsuario = new Usuario(user, password);
            return nuevoUsuario;
        }
    }
}
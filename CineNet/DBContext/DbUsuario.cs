using CineNet.Models.Core;
using CineNet.Models;

namespace CineNet.DBContext
{
    public static class DbUsuario
    {
        public static Usuario ValidarYObtenerUsuario(string user, string password)
        {
            Usuario nuevoDb = new CoreUsuario(user, password).ValidarYObtenerUsuario();
            return nuevoDb;
        }
    }
}
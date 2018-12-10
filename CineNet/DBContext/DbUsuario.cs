using AgenciaMedica.Models.Core;
using CineNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CineNet.DBContext
{
    public static class DbUsuario
    {
        public static Usuario ValidarYObtenerUsuario(string user, string password)
        {
            //FactoryUsuario nuevoUsuario = new FactoryUsuario();
            Usuario nuevoDb = new CoreUsuario(user, password).ValidarYObtenerUsuario();// nuevoUsuario.GetUsuario(user, password);
            //Usuario nuevo = CineHandler.
            return nuevoDb;
        }
    }
}
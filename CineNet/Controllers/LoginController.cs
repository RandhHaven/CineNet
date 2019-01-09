using AgenciaMedica.Models.Core;
using CineNet.Base;
using CineNet.DBContext;
using CineNet.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace CineNet.Controllers
{
    public class LoginController : CineController
    {
        
        // GET: Login
        public ActionResult ViewLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(string user, string password)
        {
            //Crear todo el esquema de ingreso.
            Usuario unUsuario = new CoreUsuario(user, password).ValidarYObtenerUsuario();
            if (object.Equals(unUsuario, null))
            {
            }
            else
            {
            }
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(string userName, string email, string password)
        {
            //Usuario usuario = CoreUsuario.RegistrarNuevoUsuario(userName, email, password);
            return View();
        }
    }
}
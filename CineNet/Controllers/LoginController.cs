using CineNet.DBContext;
using CineNet.Models;
using System.Web.Mvc;

namespace CineNet.Controllers
{
    public class LoginController : Controller
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
            Usuario usuario = DbUsuario.ValidarYObtenerUsuario(user, password);
            if (object.Equals(usuario, null))
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
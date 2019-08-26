namespace CineNet.Controllers
{
    #region Directives
    using CineNet.Models.Core;
    using CineNet.Base;
    using CineNet.Models;
    using System;
    using System.Web.Mvc;
    #endregion

    #region Class
    public class LoginController : CineController
    {
        public Usuario unUsuario = new Usuario();
        // GET: Login
        public ActionResult ViewLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewLogin(string user, string password)
        {
            try
            {
                //Crear todo el esquema de ingreso.
                Usuario unUsuario = new CoreUsuario(user, password).ValidarYObtenerUsuario();
                if (Object.Equals(unUsuario, null))
                {
                    //Si existe usuario, redireccionar a la pantalla de inicio
                }
                else
                {
                    //si no existe mostrar mensaje de error.
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(unUsuario);
        }
    }
    #endregion
}
namespace CineNet.Controllers
{   
    #region Directives
    using CineNet.Base;
    using CineNet.Models;
    using System;
    using System.Web.Mvc;
    using CineNet.Models.Core;
    using System.Web.UI;
    #endregion

    #region Class
    public class RegisterController : CineController
    {
        // GET: Register
        public bool SeleccionoPersona
        {
            get
            {
                object o = Session["SeleccionoPersona"];
                return (Object.Equals(o, null)) ? false : (bool)Session["SeleccionoPersona"];
            }
            set
            {
                Session["SeleccionoPersona"] = value;
            }
        }

        public ActionResult ViewRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewRegister(string userName, string surName, string password, string mail )
        {
            Usuario unUsuario = new CoreUsuario(userName, password).ValidarYObtenerUsuario();
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ViewRegister();
        }
    }
    #endregion
}
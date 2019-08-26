namespace CineNet.Controllers
{   
    #region Directives
    using CineNet.Base;
    using CineNet.Models;
    using System;
    using System.Web.Mvc;
    using CineNet.Models.Core;
    using System.Web.UI;
    using System.Linq;
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
        public ActionResult ViewRegister(string userName, string surName, string password, string mail)
        {
            try
            {
                CoreUsuario core = new CoreUsuario(userName, password);
                core.LoadGenders();
                ViewBag.Region = core.ListGenders.Select(mod => new SelectListItem
                {
                    Text = mod.Id,
                    Value = mod.Value
                });
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
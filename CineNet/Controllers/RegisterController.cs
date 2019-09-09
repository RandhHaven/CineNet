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
        #region Atributes
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
        #endregion

        #region Methods
        public ActionResult ViewRegister()
        {
            this.OnInitialize();
            CoreCineNet.LoadGenders();
            ViewBag.Region = CoreCineNet.ListGenders.Select(mod => new SelectListItem
            {
                Text = mod.Gender,
                Value = mod.Value
            });
            return View();
        }

        [HttpPost]
        public ActionResult ViewRegister(string userName, string surName, string password, string mail)
        {
            try
            {
                RegistrarUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ViewRegister();
        }

        public override void OnInitialize()
        {
            CoreCineNet = new CoreUsuario();
        }
        #endregion
    }
    #endregion
}
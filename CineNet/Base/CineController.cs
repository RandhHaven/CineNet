namespace CineNet.Base
{
    #region Directives
    using CineNet.Models;
    using CineNet.Models.Core;
    using System;
    using System.Web.Mvc;
    #endregion

    #region Class
    public class CineController : Controller
    {
        #region Atributtes
        public CoreUsuario CoreCineNet
        {
            get
            {
                object o = Session["CoreCineNet"];
                return (Object.Equals(o, null)) ? new CoreUsuario() : (CoreUsuario)Session["CoreCineNet"];
            }
            set
            {
                Session["CoreCineNet"] = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                object o = Session["CoreCineNet"];
                return (Object.Equals(o, null)) ? new Usuario() : (Usuario)Session["CoreCineNet"];
            }
            set
            {
                Session["CoreCineNet"] = value;
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public void RegistrarUsuario()
        {
            
        }
        #endregion
    }
    #endregion
}
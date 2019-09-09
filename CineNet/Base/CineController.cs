namespace CineNet.Base
{
    #region Directives
    using CineNet.Models;
    using CineNet.Models.Core;
    using ServicesAccessCineNet.Interfaces;
    using System;
    using System.Web.Mvc;
    #endregion

    #region Class
    public abstract class CineController : Controller
    {
        #region Atributtes
        public IRegisterUserSA _IRegisterUserSA  { get; set; }

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
                object o = Session["Usuario"];
                return (Object.Equals(o, null)) ? new Usuario() : (Usuario)Session["Usuario"];
            }
            set
            {
                Session["Usuario"] = value;
            }
        }
        #endregion

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public abstract void OnInitialize();

        public void RegistrarUsuario()
        {
            try
            {
                _IRegisterUserSA.AddUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
       
    }
    #endregion
}
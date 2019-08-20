﻿namespace CineNet.Controllers
{
    #region Directives
    using AgenciaMedica.Models.Core;
    using CineNet.Base;
    using CineNet.Models;
    using System;
    using System.Web.Mvc;
    #endregion

    #region Class
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
            ViewResult viewController;
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
                    this
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            viewController = View();

            return viewController;
        }

        [HttpPost]
        public ActionResult Registrar(string userName, string email, string password)
        {
            //Usuario usuario = CoreUsuario.RegistrarNuevoUsuario(userName, email, password);
            return View();
        }
    }
    #endregion
}
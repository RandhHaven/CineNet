namespace CineNet.Models.Core
{
    #region Directives
    using CineHandler.Usuario;
    using CineNet.Models.Entities;
    using CineNetEntity;
    using System.Collections.Generic;
    using System.Web.Mvc;
    #endregion

    public class CoreUsuario : UsuarioEntity
    {
        #region Atributos
        private string user;
        private string password;
        public Usuario UnUsuario { get; set; }

        public IEnumerable<SelectListItem> ActionsList { get; set; }

        public string StudentGrade { get; set; }

        public List<Gender> ListGenders { get; set; }
        #endregion

        #region Constructor
        public CoreUsuario(string user, string password)
        {
            this.user = user;
            ActionsList = new List<SelectListItem>();
            this.password = password;
        }   
        #endregion


        public Usuario ValidarYObtenerUsuario()
        {
            Usuario nuevo = new Usuario(user, password);
            List<Dictionary<string, object>> dicUsuario = UsuarioHandler.ObtenerDictionaryUsuario(new List<Dictionary<string, object>>());

            return nuevo;
        }

        /*public Usuario RegistrarNuevoUsuario(string user, string mail, string password)
        {
            Usuario nuevoUsuario = new Usuario(user, password);
            return nuevoUsuario;
            List<Student> lstStudent = lstInterStudent.ConvertAll(x => new Student  
            {  
                Age = x.IAge,  
                Name = x.IName  
            });  
        }*/

        public void LoadGenders()
        {
            this.ListGenders = new List<Gender>();
            this.ListGenders.Add(new Gender() { Id = "M", Value = "Male" });
            this.ListGenders.Add(new Gender() { Id = "F", Value = "Female" });
        }
    }
}
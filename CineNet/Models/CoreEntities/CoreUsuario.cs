using CineHandler.Usuario;
using CineNet.Models;
using CineNetEntity;
using System.Collections.Generic;
using System.Linq;

namespace AgenciaMedica.Models.Core
{
    public class CoreUsuario : UsuarioEntity
    {
        #region Atributos
        private string user;
        private string password;
        #endregion

        #region Constructor
        public CoreUsuario(string user, string password)
        {
            this.user = user;
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
    }
}
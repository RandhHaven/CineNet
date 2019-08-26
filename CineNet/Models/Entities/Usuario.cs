namespace CineNet.Models
{
    #region Directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    #endregion

    #region Class Model
    public class Usuario
    {
        #region Atributes
        private int idUsuario;
        private string userId;
        private string userName;
        private string surName;
        private string password;
        
        private string gender;
        private string cellPhone;
        private string creditCard;
        private DateTime birthday;
        private string email;
        private int estado;
        private string estadoDescripcion;
        
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        [Required(ErrorMessage = "Please enter student name.")]
        public string UserId { get => userId; set => userId = value; }
        public string UserName{ get => userName; set => userName = value; }
        public string SurName { get => surName; set => surName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Gender { get => gender; set => gender = value; }
        public string CellPhone { get => cellPhone; set => cellPhone = value; }
       
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string CreditCard { get => creditCard; set => creditCard = value; }
        public int Estado { get => estado; set => estado = value; }
        public string EstadoDescripcion { get => estadoDescripcion; set => estadoDescripcion = value; }
        #endregion

        #region Class
        public Usuario(string usuario = null, string password = null)
        {
            this.UserName = usuario;
            this.Password = password;
        }
        #endregion

        
    }
    #endregion
}
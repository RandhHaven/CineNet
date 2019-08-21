using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineNet.Models
{
    public class Usuario
    {
        int idUsuario;
        string userId;
        string userName;
        string password;
        string email;
        int estado;
        string estadoDescripcion;
        
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        [Required(ErrorMessage = "Please enter student name.")]
        public string UserId { get => userId; set => userId = value; }
        public string UserName{ get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int Estado { get => estado; set => estado = value; }
        public string EstadoDescripcion { get => estadoDescripcion; set => estadoDescripcion = value; }

        public Usuario(string usuario = null, string password = null)
        {
            this.UserName = usuario;
            this.Password = password;
        }
    }
}
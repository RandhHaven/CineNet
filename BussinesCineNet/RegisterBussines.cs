using BussinesCineNet.Interfaces;
using CineNetEntity;
using System;

namespace CineNetBussines
{
    public class RegisterBussines : IRegisterBussines
    {
        public RegisterBussines(UsuarioEntity usuario)
        {
        }

        public void Initialize(UsuarioEntity usuario)
        {
        }

        public string NewRegisterUser()
        {
            return String.Empty;
        }
    }
}

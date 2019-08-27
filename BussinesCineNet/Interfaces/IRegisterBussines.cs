using CineNetEntity;
using System;

namespace BussinesCineNet.Interfaces
{
    public interface IRegisterBussines
    {
        void Initialize(UsuarioEntity usuario);

        string NewRegisterUser();
    }
}

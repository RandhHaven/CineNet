using BussinesCineNet.Interfaces;
using CineNetEntity;
using CineNetEntity.Helpers;

namespace WSCINENET
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceUser" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceUser.svc or ServiceUser.svc.cs at the Solution Explorer and start debugging.
    public class ServiceUser : IServiceUser
    {
        public IRegisterBussines _IRegisterBussines
        {
            get;
            set;
        }
        
        public string AddUser(string usuario)
        {
            _IRegisterBussines.Initialize((UsuarioEntity)UsuarioEntity.Deserialize(usuario));
            return (SerializationHelper.SerializeToBinaryString(_IRegisterBussines.NewRegisterUser()));
        }

        public void DeleteUser()
        {
        }
    }
}

namespace ServicesAccessCineNet
{
    #region Directives
    using CineNetBase;
    using CineNetEntity;
    using ServicesAccessCineNet.Interfaces;
    #endregion

    #region Class
    public class RegisterUserSA : AServiceAccess, IRegisterUserSA
    {
        #region Properties
        WSServiceUser.ServiceUser services = new WSServiceUser.ServiceUser();
        #endregion

        #region Constructor
        public RegisterUserSA()
        {
        }

        public RegisterUserSA(UsuarioEntity usuario)
           : base(usuario)
        { }
        #endregion

        #region Methods
        public void AddUser()
        {
            services.AddUser();
        }
        #endregion
    }
    #endregion
}

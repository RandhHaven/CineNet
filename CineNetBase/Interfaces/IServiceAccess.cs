namespace CineNetBase.Interfaces
{
    using CineNetEntity;

    public interface IServiceAccess
    {
        #region Methods
        object Deserialize();

        AbsEntity[] List();

        string Serialize(object obj);

        UsuarioEntity usuario { get; }
        #endregion
    }
}

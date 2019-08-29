namespace CineNetBase
{
    #region Atributtes
    using CineNetBase.Interfaces;
    using CineNetEntity;
    using CineNetEntity.Helpers;
    using System;
    #endregion

    #region Class
    public abstract class AServiceAccess : IServiceAccess
    {
        public virtual UsuarioEntity usuario { get; protected set; }

        protected bool lresult;
        protected string result;
        protected AbsEntity entity;
        protected AbsEntity[] entities;

        #region Builder
        public AServiceAccess()
        { }

        public AServiceAccess(UsuarioEntity usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Methods
        public string Serialize(object obj)
        {
            return (SerializationHelper.SerializeToBinaryString(obj));
        }

        public object Deserialize()
        {
            if (result == null)
                return (null);

            return (SerializationHelper.DeserializeFromBinaryString(result));
        }

        public virtual AbsEntity[] List()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    #endregion
}

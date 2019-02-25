using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace CineNetEntity
{
    [Serializable]
    [DataContract]
    [XmlRoot("Entities", Namespace = "http://directv.com.ar/Entities")]

    public class UsuarioEntity : AUsuarioEntity
    {
        public UsuarioEntity Cast()
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.Country = this.Country;
            usuario.DisplayName = this.DisplayName;
            usuario.DnnUser_id = this.DnnUser_id;
            usuario.Instance = this.Instance;
            usuario.IsActiveDirectoryUser = this.IsActiveDirectoryUser;
            usuario.Nombre = this.Nombre;
            usuario.ROL_ID = this.ROL_ID;
            usuario.USU_ID = this.USU_ID;
            return usuario;
        }
    }
}
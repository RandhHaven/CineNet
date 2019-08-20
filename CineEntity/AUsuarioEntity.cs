using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Runtime.Serialization;

namespace CineNetEntity
{
    [Serializable]
    [DataContract]
    public class AUsuarioEntity : AbsEntity
    {
        [DataMember]
        public int USU_ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public int ROL_ID { get; set; }
        //public char CAN_ID { get; set; }
        //public short SubCanal { get; set; }
        [DataMember]
        public int DnnUser_id { get; set; }
        [DataMember]
        public bool IsActiveDirectoryUser { get; set; }
        [DataMember]
        public CountryEntity Country { get; set; }
        [DataMember]
        public string Instance { get; set; }

        #region "Validation"

        public override bool IsValid()
        {
            return Validate().IsValid;
        }

        public override bool IsValid(string rule)
        {
            return Validate(rule).IsValid;
        }

        public override ValidationResults Validate()
        {
            return Validation.Validate<AUsuarioEntity>(this);
        }

        public override ValidationResults Validate(string rule)
        {
            return Validation.Validate<AUsuarioEntity>(this, rule);
        }
        #endregion
    }
}
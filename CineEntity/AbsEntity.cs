using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Text;
using CineNetBase.Helpers;

namespace CineEntity
{ 
    [Serializable]
    public abstract class AbsEntity
    {
        public static AbsEntity Deserialize(string str)
        {
            return (AbsEntity)SerializationHelper.DeserializeFromBinaryString(str);
        }

        public static AbsEntity[] DeserializeArray(string str)
        {
            return (AbsEntity[])SerializationHelper.DeserializeFromBinaryString(str);
        }

        /// <summary> 
        /// Retorna un string con la representacion de esta instancia.
        /// </summary>
        /// <returns>String con la representacion de esta instancia.</returns>
        public string Serialize()
        {
            return SerializationHelper.SerializeToBinaryString(this);
        }

        /// <summary>
        /// Retorna un string con la representacion de esta instancia.
        /// </summary>
        /// <returns>String con la representacion de esta instancia.</returns>
        public static string Serialize(object obj)
        {
            return SerializationHelper.SerializeToBinaryString(obj);
        }

        /// <summary>
        /// Devuelve un string agregando espacios entre CamelCase.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Jan 2009</date>
        /// <example>Convierte "CamelCase" a "Camel Case".</example>
        public static string ProperSpace(string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, "[A-Z]", " $0").Trim();
        }
        public int GetNumericFromString(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text.ToCharArray())
                if (Char.IsNumber(c))
                    sb.Append(c.ToString());

            return int.Parse(sb.ToString());
        }

        #region "Validation"

        private bool _isDirty = true;
        public virtual bool IsDirty
        {
            get { return _isDirty; }
        }

        public bool IsSavable()
        {
            return IsDirty && IsValid(string.Empty);
        }

        public virtual bool IsValid(string rule)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public virtual ValidationResults Validate(string rule)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public virtual ValidationResults Validate()
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        #endregion

    }
}
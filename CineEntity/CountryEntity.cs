namespace CineNetEntity
{
    #region Referencias
    using System;
    using System.Data;
    using System.Runtime.Serialization;
    using CineNetEntity.Objects;
    #endregion

    [Serializable]
    [DataContract]
    public partial class CountryEntity : AbsEntity
    {
        public CountryEntity()
        { }

        public CountryEntity(string code)
        {
            this.Code = (ECountry)Enum.Parse(typeof(ECountry), code);
        }

        [DataMember]
        public ECountry Code { get; set; }

        public enum ECountry : short
        {
            [StringValue("Argentina")]
            AR = 0,
            [StringValue("Peru")]
            PE,
            [StringValue("Uruguay")]
            UY,
            [StringValue("Colombia")]
            CO,
            [StringValue("Ecuador")]
            EC,
            [StringValue("Chile")]
            CL,
            [StringValue("Venezuela")]
            VE
        }

        public static DataTable TableToStringEnum(Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");


            for (int i = 0; i < names.Length; i++)
            {
                var nameCountry = Enum.Parse(enumType, names[i], true);
                dr = dt.NewRow();
                dr["Key"] = StringEnum.GetStringValue((ECountry)nameCountry);
                dr["Value"] = names[i];
                dt.Rows.Add(dr);
            }

            dt.DefaultView.Sort = "Key";
            return dt;
        }
    }
}
namespace CineEntity
{
    #region Directives
    using CineNetEntity;
    using System;
    #endregion

    #region Clase
    [Serializable]
    public class Token : AbsEntity
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string expires_in { get; set; }

        public string scope { get; set; }

        public bool estado { get; set; }

        public Token()
        {
            estado = false;
        }
    }
    #endregion
}

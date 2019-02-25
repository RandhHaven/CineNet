using System;

namespace CineEntity
{
    /// <summary>
    /// Clase:ApplicationEntity
    /// </summary>
    /// <author>German Romano</author>
    /// <date>Sept 2008</date>
    [Serializable]
    public partial class ApplicationEntity
    {
        public enum EApplication : short
        {
            DTVNET = 0,
            WSIBS = 2,
            SDSNET = 4,
            LIQNET = 8,
            WinService = 9,
            ControlFraude = 10,
            Cobranzas = 12,
            Presus = 13,
            Reclamos = 14,
            IBSNET = 15,
            cGestor = 16,
            VTOL = 17,
            PROCSDS = 18,
            ACTIVACIONES = 19,
            STOCK97 = 21,
            CONCILIADOR = 22
        }
    }
}
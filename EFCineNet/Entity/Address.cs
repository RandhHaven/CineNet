namespace EFCineNet.Entity
{
    #region Directivas
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    #endregion

    [Table("Address")]
    [DataContract]
    public class Address
    {
        [Key]
        [DataMember]
        public int AdrressId { get; set; }

        [DataMember]
        [Required]
        [StringLength(200)]
        public string Street { get; set; }

        [DataMember]
        [StringLength(200)]
        [Required]
        public string Phone1 { get; set; }

        [DataMember]
        [StringLength(200)]
        public string Phone2 { get; set; }

        [StringLength(200)]
        public string Mobile { get; set; }

        [StringLength(200)]
        [Required]
        public string PostalCode { get; set; }

        [DataMember]
        public int ProvinciaId { get; set; }

        [DataMember]
        public int LocalidadId { get; set; }

        [DataMember]
        public int CiudadId { get; set; }

        [StringLength(50)]
        public string Number { get; set; }

        [StringLength(50)]
        public string Piso { get; set; }

        [StringLength(50)]
        public string Torre { get; set; }
    }
}

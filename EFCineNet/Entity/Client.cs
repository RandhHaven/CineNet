namespace EFCineNet
{
    #region Directivas
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    #endregion

    #region Tabla
    [Table("Client")]
    [DataContract]
    public class Client
    {
        [Key]
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [DataMember]
        [Required]
        [StringLength(200)]
        public string FirtName { get; set; }

        [DataMember]
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [DataMember]
        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [DataMember]
        [Required]
        [StringLength(200)]
        public Address AddressClient { get; set; }

        [DataMember]
        [Required]
        public string IsSuperUser { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

    }
    #endregion
}
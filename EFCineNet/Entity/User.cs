﻿namespace EFCineNet
{
    #region Directivas
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    #endregion

    #region Tabla
    [Table("User")]
    [DataContract]
    public class User
    {
        [Key]
        [DataMember]
        public int UserId { get; set; }

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
        public string DisplayName { get; set; }

        [DataMember]
        [Required]
        public bool IsSuperUser { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [DataMember]
        [Required]
        public bool Status { get; set; }

        [DataMember]
        [Required]
        public DateTime CurrentDate { get; set; }

        [DataMember]
        [Required]
        public DateTime CurrentUsuario { get; set; }

        [DataMember]
        public DateTime ModificationDate { get; set; }

        [DataMember]
        public DateTime ModificationUser { get; set; }
    }
    #endregion
}

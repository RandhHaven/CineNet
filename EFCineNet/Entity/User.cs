using System.ComponentModel.DataAnnotations;

namespace EFCineNet
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string FirtName { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DisplayName { get; set; }

        public string IsSuperUser { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
        
        public bool Status { get; set; }
    }
}

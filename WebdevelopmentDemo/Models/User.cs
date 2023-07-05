using System.ComponentModel.DataAnnotations;

namespace WebdevelopmentDemo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  FirstName{ get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Mobile { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public int  RoleId{ get; set; }

        public virtual Role Roles { get; set; }


    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Restro.Models
{
    public class SiteAdmin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

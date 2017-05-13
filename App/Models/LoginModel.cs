using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string UserNameR { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailR { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordR { get; set; }

        [Required]
        public bool CheckBoxR { get; set; }
    }
}

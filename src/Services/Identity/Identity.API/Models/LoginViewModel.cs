using System.ComponentModel.DataAnnotations;

namespace Identity.API.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email adresi zorunlu")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

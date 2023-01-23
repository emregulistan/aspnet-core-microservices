using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Identity.API.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Ad soyad")]
        [StringLength(60)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email adresi zorunlu")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girmiş olduğunuz parola birbiri ile eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
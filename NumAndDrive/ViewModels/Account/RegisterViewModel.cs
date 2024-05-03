using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Nom d'utilisateur non valide")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Adresse mail non valide")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}

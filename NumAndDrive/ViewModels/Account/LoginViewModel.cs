using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Nom d'utilisateur non valide")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passes ne correspondent pas")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public bool IsPasswordRest { get; set; } = false;
    }
}

using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}

using NumAndDrive.Models;
using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.Areas.Admin.ViewModels.Home
{
    public class FirstConnectionViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string ConfirmationLink { get; set; } = string.Empty;
        public string UserProfilePicture { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vous devez choisir un status utilisateur")]
        public int NewStatusId { get; set; }
        [Required(ErrorMessage = "Vous devez choisi un type de conducteur")]
        public int NewDriverTypeId { get; set; }
        [Required]
        public string OldPassword { get; set; } = string.Empty;
        [Required]
        public string NewPassword { get; set; } = string.Empty;
        [Required]
        [Compare("NewPassword", ErrorMessage = "Les mots de passe sont différent")]
        public string ConfirmedNewPassword { get; set; } = string.Empty;
        public IEnumerable<Status> Statuses { get; set; } = new List<Status>();
        public IEnumerable<DriverType> DriverTypes { get; set; } = new List<DriverType>();
    }
}

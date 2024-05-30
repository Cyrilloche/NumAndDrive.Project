using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.Areas.Admin.ViewModels.UserManagement
{
    public class AddCSVFileViewModel
    {
        [Required]
        public IFormFile File { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.Areas.Admin.ViewModels.SchoolManagement
{
    public class CreateSchoolManagementViewModel
    {
        [Required(ErrorMessage = "School name field is required.")]
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ' -]+$", ErrorMessage = "Invalid lastname format")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The lastname must be between 3 and 50 characters.")]
        public string SchoolName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Street field is required.")]
        public string Street { get; set; } = string.Empty;
        [Required(ErrorMessage = "City field is required.")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Postal code field is required.")]
        public string PostalCode { get; set; } = string.Empty;
    }
}

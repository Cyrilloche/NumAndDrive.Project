using NumAndDrive.Models;

namespace NumAndDrive.Areas.Admin.ViewModels.SchoolManagement
{
    public class IndexSchoolManagementViewModel
    {
        public IEnumerable<School> Schools { get; set; } = new List<School>();
        public string NewSchoolName { get; set; } = string.Empty;
        public Address SchoolAddress { get; set; } = new Address();
    }
}

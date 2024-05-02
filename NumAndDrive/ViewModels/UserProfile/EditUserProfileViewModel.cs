﻿using NumAndDrive.Models;

namespace NumAndDrive.ViewModels.UserProfile
{
    public class EditUserProfileViewModel
    {
        public string UserProfilePicture { get; set; } = string.Empty;
        public int NewStatusId { get; set; }
        public int NewDriverTypeId { get; set; }
        public IEnumerable<Status> Statuses { get; set; } = new List<Status>();
        public IEnumerable<DriverType> DriverTypes { get; set; } = new List<DriverType>();
    }
}

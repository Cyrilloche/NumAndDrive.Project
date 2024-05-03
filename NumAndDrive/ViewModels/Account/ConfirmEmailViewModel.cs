namespace NumAndDrive.ViewModels.Account
{
    public class ConfirmEmailViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string ConfirmationLink { get; set; } = string.Empty;
    }
}

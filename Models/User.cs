namespace BlazorAssiment.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsOtpEnabled { get; set; }
        public string StaticOtp { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}

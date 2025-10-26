using BlazorAssiment.Models;



namespace BlazorAssiment.Services
{
    public class AuthService : IAuthService
    {
        private User? _currentUser;

        private readonly List<User> _users = new()
        {
            new User
            {
                Username = "john",
                Password = "123",
                Email = "john@example.com",
                IsOtpEnabled = false,
                StaticOtp = "",
                IsActive = true
            },
            new User
            {
                Username = "jane",
                Password = "456",
                Email = "jane@example.com",
                IsOtpEnabled = true,
                StaticOtp = "7890",
                IsActive = true
            },
            new User
            {
                Username = "inactive",
                Password = "000",
                Email = "inactive@example.com",
                IsOtpEnabled = false,
                StaticOtp = "",
                IsActive = false
            }
        };

        public async Task<(bool success, string message, bool requiresOtp)> LoginAsync(
            string username,
            string password,
            string? otp = null)
        {
            await Task.Delay(500); 

            // Find user
            var user = _users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            // Check if user exists
            if (user == null)
            {
                return (false, "Invalid username or password", false);
            }

            // Check password
            if (user.Password != password)
            {
                return (false, "Invalid username or password", false);
            }

            // Check if account is active
            if (!user.IsActive)
            {
                return (false, "This account is inactive. Please contact the administrator.", false);
            }

            // If OTP is enabled
            if (user.IsOtpEnabled)
            {
                // If OTP not entered yet
                if (string.IsNullOrEmpty(otp))
                {
                    return (false, "Please enter your OTP code.", true);
                }

                // Validate OTP
                if (otp != user.StaticOtp)
                {
                    return (false, "Invalid OTP code.", true);
                }
            }

            _currentUser = user;
            return (true, "Login successful!", false);
        }
        private string? pendingUser;

        public Task SavePendingUserAsync(string username)
        {
            pendingUser = username;
            return Task.CompletedTask;
        }

        public Task<(bool success, string message)> VerifyOtpAsync(string username, string otp)
        {
            if (username == "jane" && otp == "7890")
                return Task.FromResult((true, "OTP verified successfully!"));

            return Task.FromResult((false, "Invalid OTP, please try again."));
        }

        public User? GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public bool IsAuthenticated()
        {
            return _currentUser != null;
        }

        public User? GetCurrentUser()
        {
            return _currentUser;
        }
    }
}


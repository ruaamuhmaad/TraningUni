using BlazorAssiment.Models;

namespace BlazorAssiment.Services
{
    public class AuthService : IAuthService
    {
        private User? _currentUser;
        private string? _pendingUsername; 

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

            var user = _users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return (false, "Invalid username or password", false);
            }

            if (user.Password != password)
            {
                return (false, "Invalid username or password", false);
            }

            if (!user.IsActive)
            {
                return (false, "This account is inactive. Please contact the administrator.", false);
            }

            if (user.IsOtpEnabled)
            {
                if (string.IsNullOrEmpty(otp))
                {
                    return (false, "Please enter your OTP code.", true);
                }

                if (otp != user.StaticOtp)
                {
                    return (false, "Invalid OTP code.", true);
                }
            }

            _currentUser = user;
            return (true, "Login successful!", false);
        }

        public Task SavePendingUserAsync(string username)
        {
            _pendingUsername = username;
            return Task.CompletedTask;
        }

        public Task<(bool success, string message)> VerifyOtpAsync(string username, string otp)
        {
        
            var user = _users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return Task.FromResult((false, "User not found."));
            }

          
            if (user.StaticOtp == otp)
            {
                
                _currentUser = user;
                _pendingUsername = null; 
                return Task.FromResult((true, "OTP verified successfully!"));
            }

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
            _pendingUsername = null;
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
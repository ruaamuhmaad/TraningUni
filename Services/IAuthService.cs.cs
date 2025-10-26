using BlazorAssiment.Models;

namespace BlazorAssiment.Services
{
    public interface IAuthService
    {
       
        
            Task<(bool success, string message, bool requiresOtp)> LoginAsync(string username, string password, string? otp = null);
            User? GetUserByUsername(string username);
            void Logout();
            bool IsAuthenticated();
            User? GetCurrentUser();
        Task SavePendingUserAsync(string username);
        Task<(bool success, string message)> VerifyOtpAsync(string username, string otp);


    }
}

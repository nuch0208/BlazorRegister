using JWTAuthAPI.Dtos;

namespace JWTAuthAPI.Services
{
    public interface IUserService
    {
       Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationDto userRegistration);
        bool CheckUniqueUserEmail(string email);
        Task<(bool IsLoginSuccess, JWTTokenResponseDto TokenResponse)> LoginAsync(LoginDto loginPayload);
    }
}
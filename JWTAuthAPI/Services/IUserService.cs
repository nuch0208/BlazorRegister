using JWTAuthAPI.Dtos;

namespace JWTAuthAPI.Services
{
    public interface IUserService
    {
       Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationDto userRegistration);
    }
}
using JWTAuthAPI.Dtos;

namespace JWTAuthAPI.Services
{
    public interface IUserService
    {
       Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationDto userRegistration);

       bool CheckUserUniqueEmail(string email);

       Task<(bool IsLoginSuccess, JWTTokenResponseDto TokeResponse)> LoginAsync(LoginDto loginPayload);
       Task<(string ErrorMessage, JWTTokenResponseDto JwtTokenResponse)> RenewTokenAsync(RenewTokenRequestDto renewTokenRequest);
    }
}
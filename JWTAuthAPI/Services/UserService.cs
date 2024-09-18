using JWTAuthAPI.Data.Entities;
using JWTAuthAPI.Dtos;
using JWTAuthAPI.Data;
using System.Security.Cryptography;

namespace JWTAuthAPI.Services
{
    public class UserService : IUserService
    {
        private readonly MyWorldDbContext _worlDbContext;
        public UserService(MyWorldDbContext worldDbContext)
        {
            _worlDbContext = worldDbContext;
        }
        private User FromUserRegistrationModelToUserModel(UserRegistrationDto userRegistration)
        {
            return new User
            {
                Email = userRegistration.Email,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                Password = userRegistration.Password,
            };
        }
        private string HashPassword(string plainPassword)
        {
            byte[] salt = new byte[16];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var rfcPassword = new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassword.GetBytes(20);
            byte[] passwordHash = new byte[36];
            Array.Copy(salt, 0, passwordHash, 0, 16);
            Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);
            return Convert.ToBase64String(passwordHash);
        }
        public async Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationDto userRegistration)
        {
            var isUserExist = _worlDbContext.User.Any(_ => _.Email.ToLower() == userRegistration.Email.ToLower());
            if (isUserExist)
            {
                return (false, "Email Adddress Already Registred");
            }
            var newUser = FromUserRegistrationModelToUserModel(userRegistration);
            newUser.Password = HashPassword(newUser.Password);

            _worlDbContext.User.Add(newUser);
            await _worlDbContext.SaveChangesAsync();
            return (true, "Success");
        }
    }
}
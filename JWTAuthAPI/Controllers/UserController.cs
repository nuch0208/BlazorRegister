using JWTAuthAPI.Dtos;
using JWTAuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    
        [HttpPost("register")]
        public async Task<IActionResult> UserRegistration(UserRegistrationDto userRegistration)
        {
            var result = await _userService.RegisterNewUserAsync(userRegistration);
            if(result.IsUserRegistered)
            {
                return Ok(result.Message);
            }
            ModelState.AddModelError("Email", result.Message);
            return BadRequest(ModelState);
        }
    }
}
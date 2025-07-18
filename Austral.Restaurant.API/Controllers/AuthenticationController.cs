using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Austral.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthenticationController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }
    
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticationRequestDto request)
        {
            var user = _userService.ValidateUser(request);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
    
            var token = _tokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
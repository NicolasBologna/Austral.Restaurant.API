using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Controllers;

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

    [AllowAnonymous]
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
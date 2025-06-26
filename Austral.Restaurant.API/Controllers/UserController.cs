using Microsoft.AspNetCore.Mvc;
using Austral.Restaurant.API.Services.Interfaces;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost]
    public IActionResult Create(CreateUserRequestDto request)
    {
        UserResponseDto? newUser = _userService.CreateUser(request);
        return Ok(newUser);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}

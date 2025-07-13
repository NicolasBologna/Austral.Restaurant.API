using Microsoft.AspNetCore.Mvc;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetUserById(id);

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(CreateUserRequestDto request)
    {
        UserResponseDto? newUser = _userService.CreateUser(request);

        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateUserRequestDto request)
    {
        var updatedUser = _userService.UpdateUser(id, request);

        return Ok(updatedUser);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _userService.DeleteUser(id);

        return Ok();
    }
}

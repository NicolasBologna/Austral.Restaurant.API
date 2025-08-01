using Microsoft.AspNetCore.Mvc;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();

        return Ok(users);
    }

    [HttpGet("{userId}")]
    public IActionResult GetById(int userId)
    {
        var user = _userService.GetUserById(userId);

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(CreateUserRequestDto createUserRequest)
    {
        var newUser = _userService.CreateUser(createUserRequest);

        return Ok(newUser);
    }

    [HttpPut("{userId}")]
    public IActionResult Update(int userId, UpdateUserRequestDto updateUserRequest)
    {
        var updatedUser = _userService.UpdateUser(userId, updateUserRequest);

        return Ok(updatedUser);
    }

    [HttpDelete("{userId}")]
    public IActionResult Delete(int userId)
    {
        _userService.DeleteUser(userId);

        return Ok();
    }
}
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    
    /// <summary>
    /// HTTPGET USER BY ID (usar USERRESPONSEDTO)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>


    [HttpPost]
    public IActionResult Create(CreateUserRequestDto request)
    {
        UserResponseDto? newUser = _userService.CreateUser(request);
        return Ok(newUser);
    }


    /// <summary>
    /// HTTPPUT para hacer el UPDATE (crear UpdateUserRequestDto)
    /// [HttpPut("{userId}")]
    /// public IActionResult UpdateUser(CreateAndUpdateUserDto dto, int userId)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        _userService.DeleteUser(id);
        return Ok();
    }
}

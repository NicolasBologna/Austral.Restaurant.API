using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Austral.Restaurant.API.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            var user = _userService.GetUserById(userId);

            return Ok(user);
        }

        [AllowAnonymous]
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
}

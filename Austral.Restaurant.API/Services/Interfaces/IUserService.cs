using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces;

public interface IUserService
{
    IEnumerable<UserResponseDto> GetAll();
    UserResponseDto? GetUserById(int id);
    UserResponseDto CreateUser(CreateUserRequestDto request);
    void DeleteUser(int id);
    UserResponseDto UpdateUser(int userId, UpdateUserRequestDto request);
    UserResponseDto? ValidateUser(AuthenticationRequestDto authentication);
}
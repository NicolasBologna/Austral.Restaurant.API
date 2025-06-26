using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces
{
    public interface IUserService
    {
        UserResponseDto CreateUser(CreateUserRequestDto request);
    }
}

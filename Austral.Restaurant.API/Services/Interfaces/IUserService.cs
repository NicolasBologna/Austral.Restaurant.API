using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserResponseDto> GetAll();
        UserResponseDto CreateUser(CreateUserRequestDto request);
        void DeleteUser(int id);
    }
}

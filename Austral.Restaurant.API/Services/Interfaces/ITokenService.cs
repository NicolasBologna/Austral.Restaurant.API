using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(UserResponseDto user);
}

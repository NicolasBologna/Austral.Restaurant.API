using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using AutoMapper;

namespace Austral.Restaurant.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequestDto, User>();
        CreateMap<User, UserResponseDto>();
        // UPDATE
    }
}

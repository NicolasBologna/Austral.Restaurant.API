
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Interfaces;
using AutoMapper;

namespace Austral.Restaurant.API.Services.Implementations;

public class UserService(IMapper mapper, IUserRepository userRepository) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;

    public UserResponseDto CreateUser(CreateUserRequestDto request)
    {
        User requestUser = _mapper.Map<User>(request);
        User createdUser = _userRepository.Create(requestUser);
        return _mapper.Map<UserResponseDto>(createdUser);
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }

    public IEnumerable<UserResponseDto> GetAll()
    {
        var users = _userRepository.GetAll();
        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }
}
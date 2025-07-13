using AutoMapper;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Services.Implementations;

public class UserService(IMapper mapper, IUserRepository userRepository) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;

    public IEnumerable<UserResponseDto> GetAll()
    {
        var users = _userRepository.GetAll();

        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public UserResponseDto? GetUserById(int id)
    {
        var user = _userRepository.GetById(id);

        return _mapper.Map<UserResponseDto>(user);
    }

    public UserResponseDto CreateUser(CreateUserRequestDto request)
    {
        var requestUser = _mapper.Map<User>(request);
        var createdUser = _userRepository.Create(requestUser);

        return _mapper.Map<UserResponseDto>(createdUser);
    }

    public UserResponseDto UpdateUser(int userId, UpdateUserRequestDto request)
    {
        var user = _userRepository.GetById(userId);

        if (user == null)
        {
            throw new Exception("El usuario no existe");
        }

        _mapper.Map(request, user);
        _userRepository.SaveChanges();

        return _mapper.Map<UserResponseDto>(user);
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }
}

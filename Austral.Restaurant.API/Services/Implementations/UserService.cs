
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Interfaces;
using AutoMapper;

namespace Austral.Restaurant.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository; 
        }

        public UserResponseDto CreateUser(CreateUserRequestDto request)
        {
            User requestUser = _mapper.Map<User>(request);
            User createdUser = _userRepository.Create(requestUser);
            return _mapper.Map<UserResponseDto>(createdUser);
        }
    }
}
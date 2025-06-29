﻿using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;

namespace Austral.Restaurant.API.Repositories.Interfaces;

public interface IUserRepository
{
    bool CheckIfUserExists(int userId);
    User Create(User newUser);
    IEnumerable<User> GetAll();
    User? GetById(int userId);
    void DeleteUser(int userId);
    void Update(User updatedUser, int userId);
    User? ValidateUser(AuthenticationRequestDto authRequestBody);
}
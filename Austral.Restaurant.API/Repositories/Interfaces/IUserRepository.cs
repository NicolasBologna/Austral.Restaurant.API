using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;

namespace Austral.Restaurant.API.Repositories.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User? GetById(int userId);
    User Create(User newUser);
    void DeleteUser(int userId);
    bool CheckIfUserExists(int userId);
    User? ValidateUser(AuthenticationRequestDto authRequestBody);
    void SaveChanges();
    bool RestaurantNameExists(string restaurantName);
}
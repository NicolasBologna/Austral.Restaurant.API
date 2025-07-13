using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Repositories.Interfaces;

namespace Austral.Restaurant.API.Repositories.Implementations;

public class UserRepository(RestaurantApiContext context) : IUserRepository
{
    private readonly RestaurantApiContext _context = context;

    public IEnumerable<User> GetAll()
    {
        return _context.Users.AsEnumerable();
    }

    public User? GetById(int userId)
    {
        return _context.Users.SingleOrDefault(u => u.Id == userId);
    }

    public User Create(User newUser)
    {
        var user = _context.Users.Add(newUser).Entity;
        _context.SaveChanges();

        return user;
    }

    public void DeleteUser(int userId)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
        {
            throw new Exception("El usuario que intenta eliminar no existe.");
        }

        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public bool CheckIfUserExists(int userId)
    {
        return _context.Users.Any(user => user.Id == userId);
    }

    public User? ValidateUser(AuthenticationRequestDto authRequestBody)
    {
        return _context.Users.FirstOrDefault(x => x.RestaurantName == authRequestBody.RestaurantName && x.Password == authRequestBody.Password);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}

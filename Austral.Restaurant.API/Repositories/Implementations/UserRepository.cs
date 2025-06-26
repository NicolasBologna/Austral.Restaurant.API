using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Repositories.Interfaces;
using Mono.TextTemplating;

namespace Austral.Restaurant.API.Repositories.Implementations;

public class UserRepository(RestaurantApiContext context) : IUserRepository
{
    private readonly RestaurantApiContext _context = context;

    public User? GetById(int userId)
    {
        return _context.Users.SingleOrDefault(u => u.Id == userId);
    }

    public User? ValidateUser(AuthenticationRequestDto authRequestBody)
    {
        return _context.Users.FirstOrDefault(x => x.RestaurantName == authRequestBody.RestaurantName && x.Password == authRequestBody.Password);
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public int Create(User newUser)
    {
        var createdUser = _context.Users.Add(newUser).Entity;
        _context.SaveChanges();
        return createdUser.Id;
    }

    public void Update(User updatedUser, int userId)
    {
        User userToUpdate = _context.Users.First(u => u.Id == userId);
        userToUpdate.FirstName = updatedUser.FirstName;
        //userToUpdate.UserName = dto.NombreDeUsuario; //Esto no deberíamos actualizarlo, lo mejor es crear un dto para actualización que no contenga este campo.
        userToUpdate.LastName = updatedUser.LastName;
        userToUpdate.Password = updatedUser.Password;
        _context.SaveChanges();
    }

    public void RemoveUser(int userId)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == userId);
        if (user is null)
        {
            throw new Exception("El cliente que intenta eliminar no existe");
        }

        if (user.FirstName != "Admin")
        {
            Delete(userId);
        }
        else
        {
            Archive(userId);
        }
    }

    private void Delete(int id)
    {
        _context.Users.Remove(_context.Users.Single(u => u.Id == id));
        _context.SaveChanges();
    }

    private void Archive(int id)
    {
        User? user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            user.State = State.Archived;
        }
        _context.SaveChanges();
    }

    public bool CheckIfUserExists(int userId)
    {
        return _context.Users.Any(user => user.Id == userId);
    }
}

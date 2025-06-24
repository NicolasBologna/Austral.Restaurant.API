using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Repositories.Interfaces;

namespace Austral.Restaurant.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly RestaurantApiContext _context;

        public UserRepository(RestaurantApiContext context)
        {
            _context = context;
        }
    }
}

using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Repositories.Interfaces;

namespace Austral.Restaurant.API.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RestaurantApiContext _context;

        public CategoryRepository(RestaurantApiContext context)
        {
            _context = context;
        }
    }
}
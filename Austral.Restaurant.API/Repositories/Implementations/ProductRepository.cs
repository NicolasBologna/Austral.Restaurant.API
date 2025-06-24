using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Repositories.Interfaces;

namespace Austral.Restaurant.API.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly RestaurantApiContext _context;

        public ProductRepository(RestaurantApiContext context)
        {
            _context = context;
        }

    }
}
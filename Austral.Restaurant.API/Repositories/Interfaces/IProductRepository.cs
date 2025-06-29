using Austral.Restaurant.API.Entities;

namespace Austral.Restaurant.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product Create(Product product);
        IEnumerable<Product> GetAllByUserId(int userId);
        void Delete(int id);
    }
}

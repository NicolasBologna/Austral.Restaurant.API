using Austral.Restaurant.API.Entities;

namespace Austral.Restaurant.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByUserId(int userId);
        Product? GetByProductId(int productId);
        Product Create(Product product);
        void Delete(int id);
    }
}

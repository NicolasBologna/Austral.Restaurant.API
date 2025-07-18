using Austral.Restaurant.API.Entities;

namespace Austral.Restaurant.API.Repositories.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    IEnumerable<Product> GetAllByUserId(int userId);
    Product? GetByProductId(int productId);
    IEnumerable<Product> GetDiscountedByUserAndCategory(int userId, int categoryId);
    Product CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}

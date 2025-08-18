using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Repositories.Interfaces;

namespace Austral.Restaurant.API.Repositories.Implementations;

public class ProductRepository(RestaurantApiContext context) : IProductRepository
{
    private readonly RestaurantApiContext _context = context;

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public IEnumerable<Product> GetAllByUserId(int userId)
    {
        return _context.Products.Where(x => x.UserId == userId).ToList();
    }

    public Product? GetByProductId(int productId)
    {
        return _context.Products.FirstOrDefault(x => x.Id == productId);
    }

    public IEnumerable<Product> GetProductsByFilter(int userId, int? categoryId, bool discounted)
    {
        if (categoryId is null)
        {
            return _context.Products.Where(p => p.UserId == userId 
                && p.Discount.HasValue == discounted).ToList();
        }

        return _context.Products.Where(p => p.UserId == userId 
            && p.CategoryId == categoryId 
            && p.Discount.HasValue == discounted)
            .ToList();
    }

    public Product CreateProduct(Product newProduct)
    {
        var product = _context.Products.Add(newProduct).Entity;
        _context.SaveChanges();

        return product;
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);

        if (product is null)
        {
            throw new Exception("El producto que intenta eliminar no existe.");
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}

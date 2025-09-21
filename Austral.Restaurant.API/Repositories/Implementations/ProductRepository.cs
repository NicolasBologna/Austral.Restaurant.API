using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Austral.Restaurant.API.Repositories.Implementations;

public class ProductRepository(RestaurantApiContext context) : IProductRepository
{
    private readonly RestaurantApiContext _context = context;

    public IEnumerable<Product> GetAll()
    {
        return _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .ToList();
    }

    public IEnumerable<Product> GetAllByUserId(int userId)
    {
        return _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToList();
    }

    public Product? GetByProductId(int productId)
    {
        return _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == productId);
    }

    public IEnumerable<Product> GetProductsByFilter(int userId, int? categoryId, bool discounted)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .Where(p => p.UserId == userId);

        if (discounted)
        {
            query = query.Where(p => p.Discount.HasValue && p.Discount > 0);
        }
        else
        {
            query = query.Where(p => !p.Discount.HasValue || p.Discount == 0);
        }

        if (categoryId is not null)
        {
            query = query.Where(p => p.CategoryId == categoryId);
        }

        return query.ToList();
    }

    public Product CreateProduct(Product newProduct)
    {
        var product = _context.Products.Add(newProduct).Entity;
        _context.SaveChanges();

        _context.Entry(product).Reference(p => p.Category).Load();

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
﻿using Austral.Restaurant.API.Data;
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

    public Product Create(Product newProduct)
    {
        Product product = _context.Products.Add(newProduct).Entity;
        _context.SaveChanges();
        return product;
    }

    public void Delete(int id)
    {
        Product? product = _context.Products.FirstOrDefault(x => x.Id == id);
        if (product is null)
        {
            throw new Exception("El producto que intenta eliminar no existe");
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

}
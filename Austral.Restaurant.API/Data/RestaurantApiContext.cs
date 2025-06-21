using Microsoft.EntityFrameworkCore;
using restaurante_backend.Entities;

namespace restaurante_backend.Data;

public class RestaurantApiContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public RestaurantApiContext(DbContextOptions<RestaurantApiContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
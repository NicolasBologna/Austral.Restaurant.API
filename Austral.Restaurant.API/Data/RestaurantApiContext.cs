using Microsoft.EntityFrameworkCore;
using Austral.Restaurant.API.Entities;

namespace Austral.Restaurant.API.Data;

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

        modelBuilder.Entity<Product>()
            .HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
using Austral.Restaurant.API.Models.Enum;

namespace Austral.Restaurant.API.Entities;

public class Product
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool Featured { get; set; }
    public Label Labels { get; set; } = Label.None;
    public int? RecommendedFor { get; set; }
    public int? Discount { get; set; }
    public bool HasHappyHour { get; set; }
}
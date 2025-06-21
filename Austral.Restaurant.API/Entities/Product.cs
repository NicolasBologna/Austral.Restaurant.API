using restaurante_backend.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurante_backend.Entities;

public class Product
{
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int? UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Price { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
    public int? CategoryId { get; set; }
    public bool Featured { get; set; }
    public Label Lagel { get; set; }
    public Size Size { get; set; }
    public int? RecommendedFor { get; set; }
    public int? Discount { get; set; }
    public bool HasHappyHour { get; set; }
}
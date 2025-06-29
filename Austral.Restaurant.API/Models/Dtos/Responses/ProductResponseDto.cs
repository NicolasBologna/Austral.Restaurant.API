using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Enum;

namespace Austral.Restaurant.API.Models.Dtos.Responses
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Price { get; set; }
        public Category? Category { get; set; }
        public bool Featured { get; set; }
        public Label Label { get; set; }
        public Size Size { get; set; }
        public int? RecommendedFor { get; set; }
        public int? Discount { get; set; }
        public bool HasHappyHour { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace restaurante_backend.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [ForeignKey("UserId")]
    public User? User { get; set; } = null!;
    public int UserId { get; set; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
}
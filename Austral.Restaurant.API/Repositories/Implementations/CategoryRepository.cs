using Austral.Restaurant.API.Data;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Repositories.Interfaces;

namespace Austral.Restaurant.API.Repositories.Implementations
{
    public class CategoryRepository(RestaurantApiContext context) : ICategoryRepository
    {
        private readonly RestaurantApiContext _context = context;

        public IEnumerable<Category> GetAllByUserId(int userId)
        {
            return _context.Categories.Where(x => x.UserId == userId).ToList();
        }

        public Category Create(Category newCategory)
        {
            Category category = _context.Categories.Add(newCategory).Entity;
            _context.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            Category? category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category is null)
            {
                throw new Exception("El categoria que intenta eliminar no existe");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
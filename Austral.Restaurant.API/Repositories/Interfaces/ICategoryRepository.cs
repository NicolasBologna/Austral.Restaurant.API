using Austral.Restaurant.API.Entities;

namespace Austral.Restaurant.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllByUserId(int userId);
        Category? GetById(int id);
        Category Create(Category newCategory);
        void Update(Category category);
        void Delete(int id);
    }
}
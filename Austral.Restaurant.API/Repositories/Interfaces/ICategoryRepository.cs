using Austral.Restaurant.API.Entities;

namespace Austral.Restaurant.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllByUserId(int userId);
        Category Create(Category newCategory);
        void Delete(int id);
    }
}

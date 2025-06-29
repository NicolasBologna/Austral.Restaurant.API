using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryResponseDto> GetAllByUserId(int userId);
        CategoryResponseDto Create(CreateCategoryRequestDto request);
        void Delete(int id);
    }
}

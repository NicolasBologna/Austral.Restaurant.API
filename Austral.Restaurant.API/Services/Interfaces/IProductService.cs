using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductResponseDto> GetAll();
    IEnumerable<ProductResponseDto> GetAllByUserIdAsync(int userId, int? categoryId = null, bool discounted = false);
    ProductResponseDto GetByProductId(int productId);
    ProductResponseDto Create(CreateProductRequestDto request);
    ProductResponseDto UpdateProduct(int productId, UpdateProductRequestDto request);
    ProductResponseDto ActivateHappyHour(int productId);
    ProductResponseDto SetDiscount(int productId, int discount);
    void Delete(int id);
}
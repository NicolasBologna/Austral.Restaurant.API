using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductResponseDto> GetAll();
    IEnumerable<ProductResponseDto> GetAllByUserIdAsync(int userId);
    ProductResponseDto GetByProductId(int productId);
    IEnumerable<ProductResponseDto> GetDiscountedProducts(int userId, int categoryId);
    ProductResponseDto Create(CreateProductRequestDto request);
    ProductResponseDto UpdateProduct(int productId, UpdateProductRequestDto request);
    ProductResponseDto ActivateHappyHour(int productId);
    ProductResponseDto SetDiscount(int productId, int discount);
    void Delete(int id);
}
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Services.Interfaces;

public interface IProductService
{
    IEnumerable<ProductResponseDto> GetAll();
    IEnumerable<ProductResponseDto> GetAllByUserIdAsync(int userId);
    ProductResponseDto GetByProductId(int productId);
    ProductResponseDto Create(CreateProductRequestDto request);
    //Task<ProductResponseDto> UpdateAsync(UpdateProductRequestDto request, int productId);
    void Delete(int id);
}
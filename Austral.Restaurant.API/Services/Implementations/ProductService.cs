using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Interfaces;
using AutoMapper;

namespace Austral.Restaurant.API.Services.Implementations;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public ProductResponseDto Create(CreateProductRequestDto request)
    {
        Product product = _mapper.Map<Product>(request);
        Product createdProduct = _productRepository.Create(product);
        return _mapper.Map<ProductResponseDto>(createdProduct);
    }
    public IEnumerable<ProductResponseDto> GetAll()
    {
        IEnumerable<Product> products = _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }

    public IEnumerable<ProductResponseDto> GetAllByUserIdAsync(int userId)
    {
        IEnumerable<Product> products = _productRepository.GetAllByUserId(userId);
        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }

    public void Delete(int id)
    {
        _productRepository.Delete(id);
    }

    public ProductResponseDto GetByProductId(int productId)
    {
        Product? product = _productRepository.GetByProductId(productId);
        return _mapper.Map<ProductResponseDto>(product);
    }

}
using AutoMapper;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Services.Implementations;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public ProductResponseDto Create(CreateProductRequestDto request)
    {
        Product product = _mapper.Map<Product>(request);
        Product createdProduct = _productRepository.CreateProduct(product);

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

    public ProductResponseDto UpdateProduct(int id, UpdateProductRequestDto request)
    {
        var existingProduct = _productRepository.GetByProductId(id);

        if (existingProduct == null)
        {
            throw new Exception("El producto que intenta modificar no existe.");
        }

        _mapper.Map(request, existingProduct);
        _productRepository.UpdateProduct(existingProduct);

        return _mapper.Map<ProductResponseDto>(existingProduct);
    }

    public void Delete(int id)
    {
        _productRepository.DeleteProduct(id);
    }

    public ProductResponseDto GetByProductId(int productId)
    {
        Product? product = _productRepository.GetByProductId(productId);

        return _mapper.Map<ProductResponseDto>(product);
    }
}

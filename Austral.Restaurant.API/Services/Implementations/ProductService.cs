using AutoMapper;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductResponseDto CreateForUser(CreateProductRequestDto request, int userId)
        {
            var product = _mapper.Map<Product>(request);

            product.UserId = userId;
            product.User = null;
            product.Category = null;

            var created = _productRepository.CreateProduct(product);

            var withCategory = _productRepository.GetByProductId(created.Id);

            return _mapper.Map<ProductResponseDto>(withCategory);
        }

        public IEnumerable<ProductResponseDto> GetAll()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public ProductResponseDto UpdateProduct(int id, UpdateProductRequestDto request)
        {
            Product? existingProduct = _productRepository.GetByProductId(id);

            if (existingProduct == null)
                throw new Exception("El producto que intenta modificar no existe.");

            _mapper.Map(request, existingProduct);
            _productRepository.UpdateProduct(existingProduct);

            var withCategory = _productRepository.GetByProductId(existingProduct.Id);

            return _mapper.Map<ProductResponseDto>(withCategory);
        }

        public ProductResponseDto ActivateHappyHour(int productId)
        {
            Product? product = _productRepository.GetByProductId(productId);
            if (product == null)
                throw new Exception("Producto no encontrado.");

            product.HasHappyHour = !product.HasHappyHour;
            _productRepository.UpdateProduct(product);

            var withCategory = _productRepository.GetByProductId(product.Id);

            return _mapper.Map<ProductResponseDto>(withCategory);
        }

        public ProductResponseDto SetDiscount(int productId, int discount)
        {
            if (discount < 0 || discount > 100)
                throw new ArgumentException("El descuento debe estar entre 0 y 100.");

            Product? product = _productRepository.GetByProductId(productId);
            if (product == null)
                throw new Exception("Producto no encontrado.");

            product.Discount = discount;
            _productRepository.UpdateProduct(product);

            var withCategory = _productRepository.GetByProductId(product.Id);

            return _mapper.Map<ProductResponseDto>(withCategory);
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

        public IEnumerable<ProductResponseDto> GetAllByUserIdAsync(int userId, int? categoryId = null, bool discounted = false)
        {
            IEnumerable<Product> products = _productRepository.GetProductsByFilter(userId, categoryId, discounted);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }
    }
}
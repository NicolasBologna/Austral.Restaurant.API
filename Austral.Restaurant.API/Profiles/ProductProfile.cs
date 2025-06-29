using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using AutoMapper;

namespace Austral.Restaurant.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();
            // UPDATE
        }
    }
}

using AutoMapper;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Extensions;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequestDto, Product>()
            .ForMember(d => d.Labels, o => o.MapFrom(s => s.Labels.ToFlags()))
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());

        CreateMap<Product, ProductResponseDto>()
             .ForMember(d => d.Labels, o => o.MapFrom(s => s.Labels.ToList()))
             .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category != null ? s.Category.Name : null));

        CreateMap<UpdateProductRequestDto, Product>()
            .ForMember(d => d.Labels, o => o.PreCondition(s => s.Labels != null))
            .ForMember(d => d.Labels, o => o.MapFrom(s => s.Labels!.ToFlags()))
            .ForMember(d => d.UserId, o => o.Ignore())
            .ForMember(d => d.User, o => o.Ignore());
    }
}
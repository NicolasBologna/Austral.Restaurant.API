using AutoMapper;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;

namespace Austral.Restaurant.API.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryRequestDto, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<UpdateCategoryRequestDto, Category>();
    }
}

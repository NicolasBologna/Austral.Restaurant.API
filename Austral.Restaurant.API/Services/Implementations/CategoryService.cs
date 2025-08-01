using AutoMapper;
using Austral.Restaurant.API.Entities;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Models.Dtos.Responses;
using Austral.Restaurant.API.Repositories.Interfaces;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Services.Implementations;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<CategoryResponseDto> GetAllByUserId(int userId)
    {
        var categories = _categoryRepository.GetAllByUserId(userId);

        return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
    }

    public CategoryResponseDto CreateCategory(CreateCategoryRequestDto createCategoryRequest, int userId)
    {
        var category = _mapper.Map<Category>(createCategoryRequest);
        category.UserId = userId;

        var createdCategory = _categoryRepository.Create(category);

        return _mapper.Map<CategoryResponseDto>(createdCategory);
    }

    public CategoryResponseDto UpdateCategory(int id, UpdateCategoryRequestDto updateCategoryRequest)
    {
        var category = _categoryRepository.GetById(id);

        if (category == null)
        {
            throw new Exception("La categoría que intenta modificar no existe.");
        }

        _mapper.Map(updateCategoryRequest, category);

        _categoryRepository.Update(category);

        return _mapper.Map<CategoryResponseDto>(category);
    }

    public void Delete(int id)
    {
        _categoryRepository.Delete(id);
    }
}
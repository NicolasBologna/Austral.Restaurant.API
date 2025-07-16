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

    public CategoryResponseDto CreateCategory(CreateCategoryRequestDto request)
    {
        Category category = _mapper.Map<Category>(request);
        Category createdCategory = _categoryRepository.Create(category);

        return _mapper.Map<CategoryResponseDto>(createdCategory);
    }

    public IEnumerable<CategoryResponseDto> GetAllByUserId(int userId)
    {
        var categories = _categoryRepository.GetAllByUserId(userId);

        return _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
    }

    public CategoryResponseDto UpdateCategory(int id, UpdateCategoryRequestDto request)
    {
        var category = _categoryRepository.GetById(id);

        if (category == null)
        {
            throw new Exception("La categoría que intenta modificar no existe.");
        }

        _mapper.Map(request, category);

        _categoryRepository.Update(category);

        return _mapper.Map<CategoryResponseDto>(category);
    }

    public void Delete(int id)
    {
        _categoryRepository.Delete(id);
    }
}
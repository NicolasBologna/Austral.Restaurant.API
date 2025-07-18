using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Austral.Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetAllByUserId(int userId)
    {
        var categories = _categoryService.GetAllByUserId(userId);

        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryRequestDto request)
    {
        var newCategory = _categoryService.CreateCategory(request);

        return Ok(newCategory);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateCategoryRequestDto request)
    {
        var updatedCategory = _categoryService.UpdateCategory(id, request);

        return Ok(updatedCategory);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);

        return Ok();
    }
}

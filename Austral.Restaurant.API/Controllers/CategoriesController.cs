using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Austral.Restaurant.API.Controllers;

[Authorize]
[Route("api/categories")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet("~/api/users/{userId}/categories")]
    [AllowAnonymous]
    public IActionResult GetAllByUserId(int userId)
    {
        var categories = _categoryService.GetAllByUserId(userId);

        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryRequestDto createCategoryRequest)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

        var newCategory = _categoryService.CreateCategory(createCategoryRequest, userId);

        return Ok(newCategory);
    }

    [HttpPut("{categoryId}")]
    public IActionResult Update(int categoryId, UpdateCategoryRequestDto updateCategoryRequest)
    {
        var updatedCategory = _categoryService.UpdateCategory(categoryId, updateCategoryRequest);

        return Ok(updatedCategory);
    }

    [HttpDelete("{categoryId}")]
    public IActionResult Delete(int categoryId)
    {
        _categoryService.Delete(categoryId);

        return Ok();
    }
}
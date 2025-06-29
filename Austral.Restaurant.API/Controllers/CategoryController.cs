using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Implementations;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Austral.Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryRequestDto request)
    {
        var newCategory = _categoryService.Create(request);
        return Ok(newCategory);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);
        return Ok();
    }
}

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;

namespace Austral.Restaurant.API.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("~/api/users/{userId}/products")]
    [AllowAnonymous]
    public IActionResult GetAll(int userId, [FromQuery] int? categoryId, [FromQuery] bool discounted)
    {
        var products = _productService.GetAllByUserIdAsync(userId, categoryId, discounted);
        return Ok(products);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult GetMyProducts([FromQuery] int? categoryId, [FromQuery] bool discounted)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                        ?? User.FindFirst("sub")?.Value;

        if (!int.TryParse(userIdStr, out var userId))
        {
            return Unauthorized("Token sin userId válido.");
        }

        var products = _productService.GetAllByUserIdAsync(userId, categoryId, discounted);

        return Ok(products);
    }

    [HttpGet("{productId}")]
    [AllowAnonymous]
    public IActionResult GetById(int productId)
    {
        var product = _productService.GetByProductId(productId);

        if (product is null)
        {
            return BadRequest("El producto indicado no existe.");
        }

        return Ok(product);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create([FromBody] CreateProductRequestDto request)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                        ?? User.FindFirst("sub")?.Value;

        if (!int.TryParse(userIdStr, out var userId))
        {
            return Unauthorized("Token sin userId válido.");
        }

        var newProduct = _productService.CreateForUser(request, userId);

        return Ok(newProduct);
    }

    [HttpPut("{productId}")]
    public IActionResult Update(int productId, [FromBody] UpdateProductRequestDto request)
    {
        var updatedProduct = _productService.UpdateProduct(productId, request);

        return Ok(updatedProduct);
    }

    [HttpPut("{productId}/happyHour")]
    public IActionResult ActivateHappyHour(int productId)
    {
        var updatedProduct = _productService.ActivateHappyHour(productId);

        return Ok(updatedProduct);
    }

    [HttpPut("{productId}/discount")]
    public IActionResult SetDiscount(int productId, [FromBody] SetDiscountRequestDto request)
    {
        var updatedProduct = _productService.SetDiscount(productId, request.Discount);

        return Ok(updatedProduct);
    }

    [HttpDelete("{productId}")]
    public IActionResult Delete(int productId)
    {
        _productService.Delete(productId);

        return Ok();
    }
}

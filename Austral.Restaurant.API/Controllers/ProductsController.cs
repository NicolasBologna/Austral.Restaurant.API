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

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();

        return Ok(products);
    }

    [HttpGet("me")]
    [AllowAnonymous]
    public IActionResult GetMyProducts()
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
        var products = _productService.GetAllByUserIdAsync(userId);

        return Ok(products);
    }

    [HttpGet("{productId}")]
    [AllowAnonymous]
    public IActionResult GetById(int productId)
    {
        var product = _productService.GetByProductId(productId);

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(CreateProductRequestDto request)
    {
        var newProduct = _productService.Create(request);

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
    public IActionResult SetDiscount(int productId, [FromQuery] int discount)
    {
        var updatedProduct = _productService.SetDiscount(productId, discount);

        return Ok(updatedProduct);
    }

    [HttpGet("me/discounted")]
    public IActionResult GetMyDiscountedProducts([FromQuery] int categoryId)
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
        var products = _productService.GetDiscountedProducts(userId, categoryId);

        return Ok(products);
    }

    [HttpDelete("{productId}")]
    public IActionResult Delete(int productId)
    {
        _productService.Delete(productId);

        return Ok();
    }
}

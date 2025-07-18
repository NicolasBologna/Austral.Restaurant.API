using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Austral.Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("all")]
    [AllowAnonymous]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();

        return Ok(products);
    }

    [HttpGet("user/{userId}")]
    [AllowAnonymous]
    public IActionResult GetAllByUserId(int userId)
    {
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

    [HttpPost("create")]
    public IActionResult Create(CreateProductRequestDto request)
    {
        var newProduct = _productService.Create(request);

        return Ok(newProduct);
    }

    [HttpPut("update/{productId}")]
    public IActionResult Update(int productId, [FromBody] UpdateProductRequestDto request)
    {
        var updatedProduct = _productService.UpdateProduct(productId, request);

        return Ok(updatedProduct);
    }

    [HttpPut("happyhour/{productId}")]
    public IActionResult ActivateHappyHour(int productId)
    {
        var updatedProduct = _productService.ActivateHappyHour(productId);
        return Ok(updatedProduct);
    }

    [HttpPut("discount/{productId}")]
    public IActionResult SetDiscount(int productId, [FromQuery] int discount)
    {
        var updatedProduct = _productService.SetDiscount(productId, discount);
        return Ok(updatedProduct);
    }

    [HttpGet("discounted")]
    [AllowAnonymous]
    public IActionResult GetDiscountedProducts([FromQuery] int userId, [FromQuery] int categoryId)
    {
        var products = _productService.GetDiscountedProducts(userId, categoryId);
        return Ok(products);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);

        return Ok();
    }
}

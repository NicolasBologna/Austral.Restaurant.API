using Austral.Restaurant.API.Models.Dtos.Requests;
using Austral.Restaurant.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Austral.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public IActionResult GetAllByUserId(int userId)
        {
            var products = _productService.GetAllByUserIdAsync(userId);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequestDto request)
        {
            var newProduct = _productService.Create(request);
            return Ok(newProduct);
        }


        /// <summary>
        /// HTTPPUT para hacer el UPDATE (crear UpdateUserRequestDto)
        /// [HttpPut("{userId}")]
        /// public IActionResult UpdateUser(CreateAndUpdateUserDto dto, int userId)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}

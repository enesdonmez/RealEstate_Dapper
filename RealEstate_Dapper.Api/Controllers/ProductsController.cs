using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.ProductRepository;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var products = await _productRepository.GetAllProductAsync();
            return Ok(products);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var productsWithCategories = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(productsWithCategories);
        }
    }
}

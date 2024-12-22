using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.ProductRepository;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetProductDetailById")]
        public async Task<IActionResult> GetProductDetailById(int id)
        {
            var result = await _productRepository.GetProductDetailById(id);
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.ProductImagesRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        [HttpGet("GetProductImagesByProductId")]
        public async Task<IActionResult> GetProductImagesByProductId(int id)
        {
            var values = await _productImageRepository.GetProductImagesByProductId(id);
            return Ok(values);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.ProductDtos;
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

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("Güncellendi");

        }

        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("Güncellendi");

        }

        [HttpGet("LastFiveProductList")]
        public async Task<IActionResult> GetLast5Product()
        {
            var products = await _productRepository.GetLast5ProductAsync();
            return Ok(products);
        }

        [HttpGet("GetLast3Product")]
        public async Task<IActionResult> GetLast3Product()
        {
            var products = await _productRepository.GetLast3ProductAsync();
            return Ok(products);
        }

        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var list = await _productRepository.GetProductAdvertListByEmployeeAsyncByTrue(id);
            return Ok(list);
        }

        [HttpGet("ProductAdvertsListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByFalse(int id)
        {
            var result = await _productRepository.GetProductAdvertListByEmployeeAsyncByFalse(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productRepository.CreateProduct(createProductDto);
            return Ok("ekleme başarılı");
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productRepository.GetProductById(id);
            return Ok(result);
        }

        [HttpGet("ProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKey , int propertyCategory , string city)
        {
            var result = await _productRepository.ResultProductWithSearchList(searchKey, propertyCategory, city);
            return Ok(result);
        }

        [HttpGet("GetProductByDealOfTheDayTrue")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrue()
        {
            var result = await _productRepository.GetProductByDealOfTheDayTrueAsync();
            return Ok(result);
        }
    }
}

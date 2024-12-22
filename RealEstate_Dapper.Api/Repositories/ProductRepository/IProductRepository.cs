using RealEstate_Dapper.Api.Dtos.ProductDetailDto;
using RealEstate_Dapper.Api.Dtos.ProductDtos;

namespace RealEstate_Dapper.Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultLastFiveProductWithCategoryDto>> GetLAst5ProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);
        Task CreateProduct(CreateProductDto createProductDto);
        Task<GetProductByIdDto> GetProductById(int id);
        Task<GetProductDetailByIdDto> GetProductDetailById(int id);
    }
}

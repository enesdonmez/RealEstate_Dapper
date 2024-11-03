using RealEstate_Dapper.Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper.Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    }
}

using RealEstate_Dapper.Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper.Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<GetByIDCategoryDto> GetCategoryAsync(int id);


    }
}

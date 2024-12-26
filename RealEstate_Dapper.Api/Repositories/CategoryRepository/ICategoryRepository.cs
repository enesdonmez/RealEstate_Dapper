using RealEstate_Dapper.Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper.Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
      
        Task<List<ResultCategoryDto>> GetAllCategory();
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<GetByIDCategoryDto> GetCategory(int id);

    }
}

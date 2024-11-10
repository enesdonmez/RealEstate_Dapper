using RealEstate_Dapper.Api.Dtos.CategoryDtos;
using RealEstate_Dapper.Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper.Api.Dtos.WhoWeAreDtos;

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

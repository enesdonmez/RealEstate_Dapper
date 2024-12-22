using RealEstate_Dapper.Api.Dtos.ProductDtos;

namespace RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILastProductsRepository
    {
        Task<List<ResultLastFiveProductWithCategoryDto>> GetLAst5ProductAsync(int id);

    }
}

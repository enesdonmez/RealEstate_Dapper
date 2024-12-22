using RealEstate_Dapper.Api.Dtos.ChartDtos;

namespace RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
        Task<List<ResultChartDto>> GetFiveCityForChart();

    }
}

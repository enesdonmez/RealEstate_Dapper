using Dapper;
using RealEstate_Dapper.Api.Dtos.ChartDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> GetFiveCityForChart()
        {
            string query = "select Top(5) City,Count(*) as 'CityCount' from Product group by city order by CityCount desc";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            }
        }
    }
}

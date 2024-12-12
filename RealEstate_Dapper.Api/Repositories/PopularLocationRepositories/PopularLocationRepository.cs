using Dapper;
using RealEstate_Dapper.Api.Dtos.PopularLocationsDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) values (@cityName,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopularLocationDto.CityName);
            parameters.Add("@imageUrl", createPopularLocationDto.ImageUrl);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePopularLocationAsync(int id)
        {
            string query = "delete from PopularLocation Where LocationID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "select * from PopularLocation";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDPopularLocationDto> GetPopularLocationAsync(int id)
        {
            var query = "Select * from PopularLocation Where LocationID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connect = _context.CreateConnection())
            {
                var value = await connect.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, parameter);
                return value;
            }
        }

        public async Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            var query = "Update PopularLocation set CityName = @cityName , ImageUrl=@imageUrl where LocationID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopularLocationDto.CityName);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("@id", updatePopularLocationDto.LocationID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

      
    }
}

using Dapper;
using RealEstate_Dapper.Api.Dtos.CategoryDtos;
using RealEstate_Dapper.Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper.Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;
        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2) Values(@title,@subtitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteWhoWeAreDetailAsync(int id)
        {
            string query = "delete from WhoWeAreDetail Where WhoWeAreDetailID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "select * from WhoWeAreDetail";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public  async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            var query = "Select * from WhoWeAreDetail Where WhoWeAreDetailID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connect = _context.CreateConnection())
            {
                var value = await connect.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameter);
                return value;
            }
        }

        public async Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            var query = "Update WhoWeAreDetail set Title = @title , Subtitle=@subtitle , Description1 = @description1 , Description2 = @description2 where WhoWeAreDetailID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", updateWhoWeAreDetailDto.WhoWeAreDetailID);
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

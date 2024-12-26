using Dapper;
using RealEstate_Dapper.Api.Dtos.AppUserDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int productId)
        {
            var query = "Select * from AppUser Where UserId = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", productId);

            using (var connect = _context.CreateConnection())
            {
                var value = await connect.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameter);
                return value;
            }
        }
    }
}

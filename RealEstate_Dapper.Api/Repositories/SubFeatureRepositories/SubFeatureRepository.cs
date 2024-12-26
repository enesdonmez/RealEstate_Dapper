using Dapper;
using Microsoft.AspNetCore.Server.HttpSys;
using RealEstate_Dapper.Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.SubFeatureRepositories
{
    public class SubFeatureRepository : ISubFeatureRepository
    {
        private readonly Context _context;

        public SubFeatureRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSubFeatureDto>> GetAllSubFeature()
        {
            string query = "Select * from SubFeature";
            using (var connect = _context.CreateConnection())
            {
                var value = await connect.QueryAsync<ResultSubFeatureDto>(query);
                return value.ToList();
            }
        }
    }
}

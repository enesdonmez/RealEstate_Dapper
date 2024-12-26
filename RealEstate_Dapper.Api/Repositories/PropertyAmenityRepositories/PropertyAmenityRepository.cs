using Dapper;
using RealEstate_Dapper.Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id)
        {
            string query = "select PropertyAmenityId,Title from PropertyAmenity inner join Amenity On Amenity.AmenityId = PropertyAmenity.AmenityId Where PropertyId = @id and Status = 1";

            DynamicParameters parameters = new();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query,parameters);
                return values.ToList();
            }

        }
    }
}

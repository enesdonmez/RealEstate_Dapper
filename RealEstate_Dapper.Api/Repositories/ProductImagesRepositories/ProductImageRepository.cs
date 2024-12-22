using Dapper;
using Microsoft.IdentityModel.Tokens;
using RealEstate_Dapper.Api.Dtos.ProductImageDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.ProductImagesRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetProductImagesByProductIdDto>> GetProductImagesByProductId(int id)
        {
            string query = "SELECT * FROM ProductImage where ProductId = @id";
            DynamicParameters parameters = new();
            parameters.Add("id", id);

            using (var connect = _context.CreateConnection())
            {
                var images = await connect.QueryAsync<GetProductImagesByProductIdDto>(query, parameters);
                return images.ToList();

            }
        }
    }
}

using Dapper;
using RealEstate_Dapper.Api.Dtos.CategoryDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "select * from Category";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) Values(@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
            }
        }
    }
}

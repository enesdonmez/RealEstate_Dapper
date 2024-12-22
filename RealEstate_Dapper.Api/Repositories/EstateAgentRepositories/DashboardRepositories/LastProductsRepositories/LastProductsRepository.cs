using Dapper;
using RealEstate_Dapper.Api.Dtos.ProductDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public class LastProductsRepository : ILastProductsRepository
    {
        private readonly Context _context;

        public LastProductsRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLastFiveProductWithCategoryDto>> GetLAst5ProductAsync(int id)
        {
            string query = "select top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,Type,AdvertisementDate from Product inner join Category on Product.ProductCategory = Category.CategoryID where EmployeeId = @employeeId order by ProductID desc";

            DynamicParameters param = new();
            param.Add("@employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLastFiveProductWithCategoryDto>(query,param);
                return values.ToList();
            }
        }
    }
}

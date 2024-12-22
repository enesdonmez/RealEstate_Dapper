using Dapper;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int AllProductCount()
        {
            string query = "Select Count(*) from Product";
            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCountByEmployeeId(int id)
        {
            string query = "Select Count(*) from Product where EmployeeID = @employeeId";

            DynamicParameters param = new();
            param.Add("@employeeId", id);

            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query,param);
                return value;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) from Product where EmployeeID = @employeeId and ProductStatus = 0";

            DynamicParameters param = new();
            param.Add("@employeeId", id);

            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query,param);
                return value;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) from Product where EmployeeID = @employeeId and ProductStatus = 1";

            DynamicParameters param = new();
            param.Add("@employeeId", id);

            using (var connect = _context.CreateConnection())
            {
                var value = connect.QueryFirstOrDefault<int>(query,param);
                return value;
            }
        }
    }
}

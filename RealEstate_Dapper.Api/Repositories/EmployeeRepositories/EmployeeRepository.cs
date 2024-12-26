using Dapper;
using RealEstate_Dapper.Api.Dtos.CategoryDtos;
using RealEstate_Dapper.Api.Dtos.EmployeeDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) Values(@employeeName,@title,@mail,@phoneNumber,@imageUrl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeName", createEmployeeDto.Name);
            parameters.Add("@title", createEmployeeDto.Title);
            parameters.Add("@mail", createEmployeeDto.Mail);
            parameters.Add("@phoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@status", true);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "delete from Employee Where EmployeeID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployee()
        {
            string query = "select * from Employee";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            var query = "Select * from Employee Where EmployeeID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connect = _context.CreateConnection())
            {
                var value = await connect.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameter);
                return value;
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var query = "Update Employee set Name = @employeeName , Title=@title , Mail=@mail , PhoneNumber=@phoneNumber, ImageUrl=@imageUrl , Status=@status  where EmployeeID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeName", updateEmployeeDto.Name);
            parameters.Add("@title", updateEmployeeDto.Title);
            parameters.Add("@mail", updateEmployeeDto.Mail);
            parameters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@status", updateEmployeeDto.Status);
            parameters.Add("@id", updateEmployeeDto.EmployeeID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

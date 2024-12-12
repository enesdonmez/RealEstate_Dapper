using Dapper;
using RealEstate_Dapper.Api.Dtos.CategoryDtos;
using RealEstate_Dapper.Api.Dtos.ServiceDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "insert into Service (ServiceName,ServiceStatus) Values(@serviceName,@serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createServiceDto.ServiceName);
            parameters.Add("@serviceStatus", true);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            string query = "Delete from Service Where ServiceID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "select * from Service";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDServiceDto> GetServiceAsync(int id)
        {
            var query = "Select * from Service Where ServiceID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connect = _context.CreateConnection())
            {
                var value = await connect.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameter);
                return value;
            }
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            var query = "Update Service set ServiceName = @serviceName , ServiceStatus=@serviceStatus where ServiceID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", updateServiceDto.ServiceName);
            parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
            parameters.Add("@id", updateServiceDto.ServiceID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

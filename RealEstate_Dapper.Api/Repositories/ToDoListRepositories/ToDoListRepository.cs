using Dapper;
using RealEstate_Dapper.Api.Dtos.ToDoListDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;
        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            string query = "insert into ToDoList (Description,ToDoListStatus) Values(@description,@toDoListStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", createToDoListDto.Description);
            parameters.Add("@toDoListStatus", true);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoList()
        {
            string query = "select * from ToDoList";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            string query = "select * from ToDoList where ToDoListID = @id";
            var param = new DynamicParameters();
            param.Add("id", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query,param);
                return values;
            }
        }

        public async Task UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            var query = "Update ToDoList set Description = @description , ToDoListStatus=@todoListStatus where ToDoListID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@description", updateToDoListDto.Description);
            parameters.Add("@todoListStatus", updateToDoListDto.ToDoListStatus);
            parameters.Add("@id", updateToDoListDto.ToDoListId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

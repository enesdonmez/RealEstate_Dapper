using Dapper;
using RealEstate_Dapper.Api.Dtos.ContactDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateContact(CreateContactDto createContactDto)
        {
            var query = "insert into Contact values(@name,@subject,@mail,@message,@sendDate)";
            var parameter = new DynamicParameters();
            parameter.Add("@name", createContactDto.Name);
            parameter.Add("@subject", createContactDto.Subject);
            parameter.Add("@mail", createContactDto.Email);
            parameter.Add("@message", createContactDto.Message);
            parameter.Add("@sendDate", createContactDto.SendDate);

            using (var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameter);

            }
        }

        public async Task DeleteContact(int id)
        {
            string query = "delete from Contact Where ContactID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContact()
        {
            string query = "select * from Contact";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdContactDto> GetContact(int id)
        {
            var query = "Select * from Contact Where ContactID = @id";
            var parameter = new DynamicParameters();
            parameter.Add("@id", id);

            using (var connect = _context.CreateConnection())
            {
                var value = await connect.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parameter);
                return value;
            }
        }

        public async Task<List<LastFourContactResultDto>> GetLastFourContact()
        {
            string query = "select top(4)* from Contact order by ContactID desc";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<LastFourContactResultDto>(query);
                return values.ToList();
            }
        }
    }
}

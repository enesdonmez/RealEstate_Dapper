using Dapper;
using RealEstate_Dapper.Api.Dtos.MessageDtos;
using RealEstate_Dapper.Api.Models.DapperContext;

namespace RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInBoxLastThreeMessageListByReceiver(int id)
        {
            string query = "select Top(3) MessageId,Name,Subject,Detail,SendDate,IsRead,UserImageUrl from Message Inner join AppUser on Message.Sender = AppUser.userId Where Receiver = @receiverId order by MessageId desc";

            DynamicParameters parameters = new();
            parameters.Add("@receiverId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}

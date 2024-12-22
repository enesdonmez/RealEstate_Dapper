using RealEstate_Dapper.Api.Dtos.MessageDtos;

namespace RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDto>> GetInBoxLastThreeMessageListByReceiver(int id);
    }
}

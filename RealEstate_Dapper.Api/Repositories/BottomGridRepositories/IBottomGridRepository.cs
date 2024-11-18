using RealEstate_Dapper.Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper.Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
        Task DeleteBottomGridAsync(int id);
        Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
        Task<GetBottomGridDto> GetBottomGridAsync(int id);
    }
}

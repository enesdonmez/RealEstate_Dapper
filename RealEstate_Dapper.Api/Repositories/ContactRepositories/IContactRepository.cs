using RealEstate_Dapper.Api.Dtos.ContactDtos;

namespace RealEstate_Dapper.Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<LastFourContactResultDto>> GetLastFourContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(int id);
        Task<GetByIdContactDto> GetContactAsync(int id);
    }
}

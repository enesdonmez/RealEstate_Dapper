using RealEstate_Dapper.Api.Dtos.ContactDtos;

namespace RealEstate_Dapper.Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContact();
        Task<List<LastFourContactResultDto>> GetLastFourContact();
        Task CreateContact(CreateContactDto createContactDto);
        Task DeleteContact(int id);
        Task<GetByIdContactDto> GetContact(int id);
    }
}

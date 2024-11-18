using RealEstate_Dapper.Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper.Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task DeleteServiceAsync(int id);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task<GetByIDServiceDto> GetServiceAsync(int id);

    }
}

using RealEstate_Dapper.Api.Dtos.AppUserDtos;

namespace RealEstate_Dapper.Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDto> GetAppUserByProductId(int productId);
    }
}

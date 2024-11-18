using RealEstate_Dapper.Api.Dtos.BottomGridDtos;
using RealEstate_Dapper.Api.Dtos.PopulerLocationsDtos;

namespace RealEstate_Dapper.Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
  
    }
}

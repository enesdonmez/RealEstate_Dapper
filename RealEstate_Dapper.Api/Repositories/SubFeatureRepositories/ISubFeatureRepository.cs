using RealEstate_Dapper.Api.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper.Api.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeature();
    }
}

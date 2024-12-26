using RealEstate_Dapper.Api.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper.Api.Repositories.PropertyAmenityRepositories
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);
    }
}

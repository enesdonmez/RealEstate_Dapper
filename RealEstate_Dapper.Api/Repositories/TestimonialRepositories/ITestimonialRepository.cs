using RealEstate_Dapper.Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper.Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();

    }
}

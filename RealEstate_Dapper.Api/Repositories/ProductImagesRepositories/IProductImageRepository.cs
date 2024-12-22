using RealEstate_Dapper.Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper.Api.Repositories.ProductImagesRepositories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImagesByProductIdDto>> GetProductImagesByProductId(int id);
    }
}

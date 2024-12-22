namespace RealEstate_Dapper.Api.Dtos.ProductImageDtos
{
    public class GetProductImagesByProductIdDto
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}

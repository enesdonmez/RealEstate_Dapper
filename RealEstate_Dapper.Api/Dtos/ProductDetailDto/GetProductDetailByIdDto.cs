namespace RealEstate_Dapper.Api.Dtos.ProductDetailDto
{
    public class GetProductDetailByIdDto
    {
        public int ProductDetailsID { get; set; }
        public decimal Price { get; set; }
        public int ProductSize { get; set; }
        public int BedroomCount { get; set; }
        public int BathCount { get; set; }
        public int RoomCount { get; set; }
        public int Garage { get; set; }
        public string BuildYear { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public int ProductID { get; set; }

    }
}

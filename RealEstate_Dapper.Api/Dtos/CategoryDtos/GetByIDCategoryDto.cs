namespace RealEstate_Dapper.Api.Dtos.CategoryDtos
{
    public class GetByIDCategoryDto
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }
    }
}

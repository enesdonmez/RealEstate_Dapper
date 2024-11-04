namespace RealEstate_Dapper.Api.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }
    }
}

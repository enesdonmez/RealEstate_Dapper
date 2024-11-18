namespace RealEstate_Dapper.UI.Dtos.TestimonialDtos
{
    public class ResultTestimonialDto
    {
        public int TestimonialID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        bool Status { get; set; }
    }
}

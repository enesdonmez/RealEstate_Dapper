namespace RealEstate_Dapper.UI.Dtos.AppUserDtos
{
    public class GetAppUserByProductIdDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string UserImageUrl { get; set; }
    }
}

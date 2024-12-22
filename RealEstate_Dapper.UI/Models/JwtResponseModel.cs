using Microsoft.AspNetCore.Server.HttpSys;

namespace RealEstate_Dapper.UI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}

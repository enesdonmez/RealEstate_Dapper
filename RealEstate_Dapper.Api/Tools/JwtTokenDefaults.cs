namespace RealEstate_Dapper.Api.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost"; //  dinleyecek
        public const string ValidIssuer = "https://localhost";   //  yayınlayacak 
        public const string Key = "RealEstate..987654321Asp.NetCore8.0**-";
        public const int Expire = 5;
    
    }
}

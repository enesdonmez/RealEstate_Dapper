using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.LoginDtos;
using RealEstate_Dapper.Api.Models.DapperContext;
using RealEstate_Dapper.Api.Tools;

namespace RealEstate_Dapper.Api.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = "Select * from Appuser where Username = @username and Password = @password";
            string query2 = "Select UserId from Appuser where Username = @username and Password = @password";
            DynamicParameters parameters = new();
            parameters.Add("@username", createLoginDto.Username);
            parameters.Add("@password", createLoginDto.Password);

            using (var connect = _context.CreateConnection())
            {
                var values = await connect.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                int id = await connect.QueryFirstOrDefaultAsync<int>(query2, parameters);
                if (values != null && id != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.UserName = values.Username;
                    model.Id = id;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                } 
                else
                    return Ok("Başarısız");
            }

        }
    }
}

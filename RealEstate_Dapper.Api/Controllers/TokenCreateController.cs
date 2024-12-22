using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Tools;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateToken(GetCheckAppUserViewModel model)
        {
            var values = JwtTokenGenerator.GenerateToken(model);
            return Ok(values);
        }





    }
}

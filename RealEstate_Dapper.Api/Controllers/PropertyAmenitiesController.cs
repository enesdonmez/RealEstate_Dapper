using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.PropertyAmenityRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiesController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAmenitiesByPropertyByStatusTrue(int id)
        {
            var res = await _propertyAmenityRepository.ResultPropertyAmenityByStatusTrue(id);

            return Ok(res);
        }
    }
}

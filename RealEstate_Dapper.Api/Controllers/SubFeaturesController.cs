using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.SubFeatureRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeaturesController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;

        public SubFeaturesController(ISubFeatureRepository subFeatureRepository)
        {
            _subFeatureRepository = subFeatureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubFeature()
        {
            var result = await _subFeatureRepository.GetAllSubFeature();
            return Ok(result);
        }
    }
}

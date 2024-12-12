using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.PopularLocationsDtos;
using RealEstate_Dapper.Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularLocationList()
        {
            var Locations = await _popularLocationRepository.GetAllPopularLocationAsync(); 
            return Ok(Locations);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            await _popularLocationRepository.CreatePopularLocationAsync(createPopularLocationDto);
            return Ok("Ekleme Başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _popularLocationRepository.UpdatePopularLocationAsync(updatePopularLocationDto);
            return Ok("güncelleme Başarılı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _popularLocationRepository.DeletePopularLocationAsync(id);
            return Ok("Lokasyon Silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocationById(int id)
        {
            var location = await _popularLocationRepository.GetPopularLocationAsync(id);
            return Ok(location);
        }

    }
}

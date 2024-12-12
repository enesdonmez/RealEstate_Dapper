using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.ServiceDtos;
using RealEstate_Dapper.Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper.Api.Repositories.CategoryRepository;
using RealEstate_Dapper.Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceRepository.CreateServiceAsync(createServiceDto);
            return Ok("Servis eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
            return Ok("Servis Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateServiceAsync(updateServiceDto);
            return Ok("Servis güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceRepository.GetServiceAsync(id);
            return Ok(service);
        }
    }
}

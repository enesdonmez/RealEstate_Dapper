using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.ContactDtos;
using RealEstate_Dapper.Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetContactList")]
        public async Task<IActionResult> GetContactList()
        {
            var values = await _contactRepository.GetAllContactAsync();
            return Ok(values);
        }

        [HttpGet("GetLastFourContactList")]
        public async Task<IActionResult> GetLastFourContactList()
        {
            var values = await _contactRepository.GetLastFourContactAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactRepository.CreateContactAsync(createContactDto);
            return Ok("Ekleme Başarılı.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _contactRepository.GetContactAsync(id);
            return Ok(values);
        }
    }
}

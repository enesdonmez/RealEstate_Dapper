using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.MessageRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInBoxLastThreeMessageListByReceiver(int id)
        {
            var result = await _messageRepository.GetInBoxLastThreeMessageListByReceiver(id);
            return Ok(result);
        }
    }
}

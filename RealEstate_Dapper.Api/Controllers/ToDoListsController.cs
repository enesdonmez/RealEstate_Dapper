using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.ToDoListDtos;
using RealEstate_Dapper.Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            var values = await _toDoListRepository.GetAllToDoList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            await _toDoListRepository.CreateToDoList(createToDoListDto);
            return Ok("eklendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdToDoList(int id)
        {
            var list = await _toDoListRepository.GetToDoList(id);
            return Ok(list);
        }

        [HttpPut("UpdateToDoList")]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            await _toDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("güncellendi.");
        }
    }
}

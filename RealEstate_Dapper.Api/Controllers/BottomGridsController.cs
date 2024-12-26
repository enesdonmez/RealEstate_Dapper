using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Dtos.BottomGridDtos;
using RealEstate_Dapper.Api.Dtos.CategoryDtos;
using RealEstate_Dapper.Api.Models.DapperContext;
using RealEstate_Dapper.Api.Repositories.BottomGridRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBottomGridList()
        {
            var value = await _bottomGridRepository.GetAllBottomGrid();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
             await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("Eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("BottomGrid Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateBottomGridDto updateBottomGridDto)
        {
            await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("BottomGrid güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var grid = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(grid);
        }
    }
}

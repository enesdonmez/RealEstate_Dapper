using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    public class EstateAgentLastProductsController : Controller
    {
        private readonly ILastProductsRepository _lastProductsRepository;

        public EstateAgentLastProductsController(ILastProductsRepository lastProductsRepository)
        {
            _lastProductsRepository = lastProductsRepository;
        }

        [HttpGet("api/EstateAgentLastProducts")]
        public async Task<IActionResult> GetLastProduct(int id)
        {
            var products = await _lastProductsRepository.GetLAst5ProductAsync(id);
            return Ok(products);
        }

    }
}

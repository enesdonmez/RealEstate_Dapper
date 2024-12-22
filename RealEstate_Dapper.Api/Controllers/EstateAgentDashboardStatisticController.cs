using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RealEstate_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statistic;

        public EstateAgentDashboardStatisticController(IStatisticRepository statistic)
        {
            _statistic = statistic;
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statistic.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statistic.ProductCountByStatusTrue(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statistic.ProductCountByStatusFalse(id));
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statistic.AllProductCount());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper.UI.Services;
using System.Net.Http;

namespace RealEstate_Dapper.UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticsComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:44377/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;

            var responseMessage2 = await client.GetAsync("https://localhost:44377/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.byEmployeeProductCount = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:44377/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=" + id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ByStatusTrueProductCount = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:44377/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=" + id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.ByStatusFalseProductCount = jsonData4;

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.EstateAgentDtos;
using RealEstate_Dapper.UI.Services;

namespace RealEstate_Dapper.UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLastProductsComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentLastProductsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userID = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/EstateAgentLastProducts?id=" + userID);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentLastProductsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.MessageDtos;
using RealEstate_Dapper.UI.Services;

namespace RealEstate_Dapper.UI.Areas.EstateAgent.ViewComponents.NavbarViewComponents
{
    public class _NavbarLastThreeMessageComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _NavbarLastThreeMessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/Messages?id=" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

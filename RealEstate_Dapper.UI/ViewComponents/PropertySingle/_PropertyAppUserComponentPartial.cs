using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.AppUserDtos;

namespace RealEstate_Dapper.UI.ViewComponents.PropertySingle
{
    public class _PropertyAppUserComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/AppUsers?productId=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAppUserByProductIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

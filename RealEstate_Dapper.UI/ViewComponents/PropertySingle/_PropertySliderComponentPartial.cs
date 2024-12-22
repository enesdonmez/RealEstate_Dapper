using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.PropertyImageDtos;

namespace RealEstate_Dapper.UI.ViewComponents.PropertySingle
{
    public class _PropertySliderComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/ProductImage/GetProductImagesByProductId?id=" + 1);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PropertyImageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper.UI.ViewComponents.PropertySingle
{
    public class _PropertyAmenityComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenityComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
             var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/PropertyAmenities?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAmenityByStatusTrueDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
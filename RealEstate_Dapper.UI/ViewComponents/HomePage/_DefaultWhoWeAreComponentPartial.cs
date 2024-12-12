using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.WhoWeAreDtos;
using RealEstate_Dapper.UI.Dtos.ServiceDtos;

namespace RealEstate_Dapper.UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44377/api/WhoWeAreDetail");
            var response2 = await client.GetAsync("https://localhost:44377/api/Services");
            if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var jsonData2 = await response2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData); 
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2); 

                ViewBag.Title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.Subtitle = value.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.Description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.Description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.ServiceDtos;
using System.Text;

namespace RealEstate_Dapper.UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44377/api/Services");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(json);
                return View(values);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44377/api/Services", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44377/api/Services/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44377/api/Services/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(data);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateServiceDto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:44377/api/Services", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}

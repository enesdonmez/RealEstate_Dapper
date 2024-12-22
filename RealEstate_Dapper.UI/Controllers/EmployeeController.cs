using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.EmployeeDtos;
using RealEstate_Dapper.UI.Services;
using System.Text;

namespace RealEstate_Dapper.UI.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public EmployeeController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Claims;
            var userId = _loginService.GetUserId;

            var token = User.Claims.FirstOrDefault(x => x.Type == "realestatetoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44377/api/Employees");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                    return View(values);
                }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createEmployeeDto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44377/api/Employees", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:44377/api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44377/api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(data);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateEmployeeDto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:44377/api/Employees", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}

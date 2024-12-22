using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.CategoryDtos;
using RealEstate_Dapper.UI.Dtos.ProductDtos;
using RealEstate_Dapper.UI.Services;
using System.Text;

namespace RealEstate_Dapper.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> ActiveAdverts()
        {
            string userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/Products/ProductAdvertsListByEmployeeByTrue?id=" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> OldAdverts()
        {
            string userId = _loginService.GetUserId;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/Products/ProductAdvertsListByEmployeeByFalse?id=" + userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44377/api/Categories");

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.categories = categoryValues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto)
        {
            createProductDto.DealOfTheDay = false;
            createProductDto.AdvertisementDate = DateTime.Now;
            createProductDto.ProductStatus = true;

            var id = _loginService.GetUserId;
            createProductDto.EmployeeID = int.Parse(id);

            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44377/api/Products", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

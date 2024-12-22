using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.ProductDetailDto;
using RealEstate_Dapper.UI.Dtos.ProductDtos;

namespace RealEstate_Dapper.UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/Products/GetProductById?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

            var responseMessage2 = await client.GetAsync("https://localhost:44377/api/ProductDetails/GetProductDetailById?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);

            ViewBag.product_title = values.Title;
            ViewBag.price = values.Price;
            ViewBag.city = values.City;
            ViewBag.district = values.District;
            ViewBag.address = values.Address;
            ViewBag.type = values.Type;
            ViewBag.dateDiff = (DateTime.Now - values.AdvertisementDate).Days;

            ViewBag.roomCount = values2.RoomCount;
            ViewBag.bedroomCount = values2.BedroomCount;
            ViewBag.bathCount = values2.BathCount;
            ViewBag.garageSize = values2.Garage;
            ViewBag.productSize = values2.ProductSize;
            ViewBag.buildYear = values2.BuildYear;


            return View();

        }
    }
}

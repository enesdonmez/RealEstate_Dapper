using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.ProductDetailDto;
using RealEstate_Dapper.UI.Dtos.ProductDtos;
using System.Text.RegularExpressions;

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

        public async Task<IActionResult> PropertyListWithSearch(string searchValue, int propertyCategoryId, string city)
        {

            searchValue = TempData["searchWord"].ToString();
            propertyCategoryId = int.Parse(TempData["category"].ToString());
            city = TempData["cityVal"].ToString();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44377/api/Products/ProductWithSearchList?searchKey={searchValue}&propertyCategory={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet("Property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(int id ,string slug)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/Products/GetProductById?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

            var responseMessage2 = await client.GetAsync("https://localhost:44377/api/ProductDetails/GetProductDetailById?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);


            ViewBag.product_title = values.Title;
            ViewBag.productId= values.ProductID;
            ViewBag.price = values.Price;
            ViewBag.city = values.City;
            ViewBag.district = values.District;
            ViewBag.address = values.Address;
            ViewBag.type = values.Type;
            ViewBag.description = values.Description;
            ViewBag.slugUrl = values.SlugUrl;
            ViewBag.dateDiff = (DateTime.Now - values.AdvertisementDate).Days;

            ViewBag.roomCount = values2.RoomCount;
            ViewBag.bedroomCount = values2.BedroomCount;
            ViewBag.bathCount = values2.BathCount;
            ViewBag.garageSize = values2.Garage;
            ViewBag.productSize = values2.ProductSize;
            ViewBag.buildYear = values2.BuildYear;
            ViewBag.location = values2.Location;
            ViewBag.video = values2.VideoUrl;
            ViewBag.i = id;


            string slugFromTitle = CreateSlug(values.Title);
            ViewBag.slugUrl = slugFromTitle;

            return View();

        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant();
            title = title.Replace(" ", "-"); 
            title = Regex.Replace(title, @"[^a-z0-9\s-]", ""); 
            title = Regex.Replace(title, @"\s+", " ").Trim(); 
            title = Regex.Replace(title, @"\s", "-"); 

            return title;
        }
    }
}

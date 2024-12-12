using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region activeCategoryCount

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;

            #endregion

            #region activeEmployeeCount

            var responseMessage2 = await client.GetAsync("https://localhost:44377/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;

            #endregion

            #region apartmentCount

            var responseMessage3 = await client.GetAsync("https://localhost:44377/api/Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;

            #endregion

            #region AverageProductPriceByRent

            var responseMessage4 = await client.GetAsync("https://localhost:44377/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = (decimal.Parse(jsonData4.Replace(".", "")) / 1000000m).ToString("N2");
          

            #endregion

            #region AverageProductPriceBySale

            var responseMessage5 = await client.GetAsync("https://localhost:44377/api/Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = (decimal.Parse(jsonData5.Replace(".", "")) / 1000000m).ToString("N2"); ;

            #endregion

            #region AverageRoomCount

            var responseMessage6 = await client.GetAsync("https://localhost:44377/api/Statistics/AverageRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.averageRoomCount = jsonData6;

            #endregion

            #region CategoryCount

            var responseMessage7 = await client.GetAsync("https://localhost:44377/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData7;

            #endregion

            #region CategoryNameByMaxProductCount

            var responseMessage8 = await client.GetAsync("https://localhost:44377/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData8;

            #endregion

            #region CityNameByMaxProductCount

            var responseMessage9 = await client.GetAsync("https://localhost:44377/api/Statistics/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData9;

            #endregion

            #region DifferentCityCount

            var responseMessage10 = await client.GetAsync("https://localhost:44377/api/Statistics/DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData10;

            #endregion

            #region EmployeeNameByMaxProductCount

            var responseMessage11 = await client.GetAsync("https://localhost:44377/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData11;

            #endregion

            #region LastProductPrice

            var responseMessage12 = await client.GetAsync("https://localhost:44377/api/Statistics/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.lastProductPrice = jsonData12;

            #endregion

            #region NewestBuildingYear

            var responseMessage13 = await client.GetAsync("https://localhost:44377/api/Statistics/NewestBuildingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.newestBuildingYear = jsonData13;

            #endregion

            #region OldestBuildingYear

            var responseMessage14 = await client.GetAsync("https://localhost:44377/api/Statistics/OldestBuildingYear");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.oldestBuildingYear = jsonData14;

            #endregion

            #region PasiveCategoryCount

            var responseMessage15 = await client.GetAsync("https://localhost:44377/api/Statistics/PasiveCategoryCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.pasiveCategoryCount = jsonData15;

            #endregion

            #region ProductCount

            var responseMessage16 = await client.GetAsync("https://localhost:44377/api/Statistics/ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData16;

            #endregion

            return View();
        }
    }
}

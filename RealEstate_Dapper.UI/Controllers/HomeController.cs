using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.CategoryDtos;
using RealEstate_Dapper.UI.Models;

namespace RealEstate_Dapper.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }


    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_apiSettings.BaseUrl);
        var responseMessage = await client.GetAsync("Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public async Task<PartialViewResult> PartialSearch()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44377/api/Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return PartialView(values);
        }
        return PartialView();
    }

    [HttpPost]
    public IActionResult PartialSearch(string word, string cityVal, int categoryId)
    {
        TempData["searchWord"] = word;
        TempData["cityVal"] = cityVal;
        TempData["category"] = categoryId;
        return RedirectToAction("PropertyListWithSearch", "Property");
    }
}
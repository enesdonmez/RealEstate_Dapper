﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper.UI.Dtos.EstateAgentDtos;

namespace RealEstate_Dapper.UI.ViewComponents.EstateAgent
{
    public class _EstateAgentChartComponentPartial : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentChartComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44377/api/EstateAgentChart");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
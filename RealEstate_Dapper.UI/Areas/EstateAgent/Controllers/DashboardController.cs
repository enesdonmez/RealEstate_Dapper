﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

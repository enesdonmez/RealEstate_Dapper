﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
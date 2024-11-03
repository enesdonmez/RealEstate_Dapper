using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
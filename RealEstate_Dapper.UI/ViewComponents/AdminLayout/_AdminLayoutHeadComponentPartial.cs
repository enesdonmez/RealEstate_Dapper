using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadComponentPartial :ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

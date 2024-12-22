using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

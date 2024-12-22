using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.ViewComponents.EstateAgent
{
    public class _EstateAgentNavbarComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

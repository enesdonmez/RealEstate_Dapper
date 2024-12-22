using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper.UI.ViewComponents.EstateAgent.EstateAgentNavbar
{
    public class _EstateAgentNavbarMessageComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

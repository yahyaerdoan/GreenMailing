using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.LayoutControllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

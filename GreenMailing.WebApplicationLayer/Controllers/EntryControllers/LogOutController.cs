using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.EntryControllers
{
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

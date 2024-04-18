using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class SentMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

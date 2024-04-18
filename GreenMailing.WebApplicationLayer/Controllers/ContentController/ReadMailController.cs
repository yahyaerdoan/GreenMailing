using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class ReadMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

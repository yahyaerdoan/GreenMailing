using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class ComposeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

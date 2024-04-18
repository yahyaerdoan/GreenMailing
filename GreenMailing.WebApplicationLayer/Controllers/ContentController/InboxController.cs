using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class InboxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

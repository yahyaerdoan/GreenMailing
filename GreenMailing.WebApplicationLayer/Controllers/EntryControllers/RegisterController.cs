using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.EntryControllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

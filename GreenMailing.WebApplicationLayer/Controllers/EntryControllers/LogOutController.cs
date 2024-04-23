using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.EntryControllers
{
    public class LogOutController : Controller
    {
        private readonly SignInManager<User> _signInManager;

		public LogOutController(SignInManager<User> signInManager)
		{
			_signInManager = signInManager;
		}

		public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "LogIn");
        }
    }
}
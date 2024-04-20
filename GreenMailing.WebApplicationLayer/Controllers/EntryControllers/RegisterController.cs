using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.EntryControllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;

		public RegisterController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

        [HttpGet]
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async  Task<IActionResult> CreateUser(User user)
		{
		
			await _userManager.CreateAsync(user);
			return RedirectToAction("Index", "LogIn");
		}
	}
}

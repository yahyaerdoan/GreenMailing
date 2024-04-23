using GreenMailing.BusinessLayer.Concrete.ValidationRules.UserValidationRules;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.EntryControllers
{
    public class LogInController : Controller
    {
        private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		LogInUserValidator _logInUserValidator = new();

		public LogInController(UserManager<User> userManager, SignInManager<User> signInManager, LogInUserValidator logInUserValidator)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logInUserValidator = logInUserValidator;
		}
		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Index(LogInUserDto logInUserDtos)
		{
			var result = _logInUserValidator.Validate(logInUserDtos);
			if (result.IsValid)
			{
				if (logInUserDtos.Email != null && logInUserDtos.Password != null)
				{
					var userInfo = await _signInManager.PasswordSignInAsync(logInUserDtos.Email, logInUserDtos.Password, false, true);
					if (userInfo.Succeeded)
					{
						return RedirectToAction("Index", "Inbox");
					}
					else
					{
						ModelState.AddModelError("", "Invalid email or password");

					}
				}
			}
			return View(logInUserDtos);
		}
	}
}
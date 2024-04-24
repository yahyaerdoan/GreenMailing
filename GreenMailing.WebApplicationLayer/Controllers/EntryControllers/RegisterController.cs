using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.BusinessLayer.Concrete.ValidationRules.UserValidationRules;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.EntryControllers
{
	public class RegisterController : Controller
	{
		private readonly IUserService _userService;
		CreateUserValidator _createUserValidator = new();
		public RegisterController(IUserService userService, CreateUserValidator createUserValidator)
		{
			_userService = userService;
			_createUserValidator = createUserValidator;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateUserDto createUserDto)
		{			
			var result = _createUserValidator.Validate(createUserDto);
			if (result.IsValid)
			{
				await _userService.CreateUserAsync(createUserDto);
				return RedirectToAction("Index", "LogIn");
			}
			else
			{
                foreach (var error in result.Errors)
                {
					ModelState.AddModelError("", error.ErrorMessage);
                }
            }
			return View(createUserDto);			
		}

		[HttpGet]
		public IActionResult UpdateUser()
		{
			return View();
		}

		[HttpPost]
		public IActionResult UpdateUserl ()
		{
			return View();
		}
	}
}
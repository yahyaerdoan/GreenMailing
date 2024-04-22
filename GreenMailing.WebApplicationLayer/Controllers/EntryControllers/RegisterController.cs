using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.DataTransferObjectLayer.Concrete.Dtos;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.EntryControllers
{
	public class RegisterController : Controller
	{
		private readonly IUserService _userService;

		public RegisterController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
		{
			await _userService.CreateUserAsync(createUserDto);
			return RedirectToAction("Index", "LogIn");
		}
	}
}
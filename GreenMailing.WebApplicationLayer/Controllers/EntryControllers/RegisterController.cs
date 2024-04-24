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
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
		CreateUserValidator _createUserValidator = new();
        public RegisterController(IUserService userService, CreateUserValidator createUserValidator, UserManager<User> userManager)
        {
            _userService = userService;
            _createUserValidator = createUserValidator;
            _userManager = userManager;
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
		public async Task<IActionResult> UpdateUser()
		{
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userInfo = _userService.Get(x => x.Id == user.Id);
			UpdateUserDto updateUserDto = new();
			updateUserDto.FirstName = userInfo.FirstName;
			updateUserDto.LastName = userInfo.LastName;
			updateUserDto.UserName = userInfo.UserName;
			updateUserDto.Image = userInfo.Image;
			updateUserDto.PhoneNumber = userInfo.PhoneNumber;
			updateUserDto.Description = userInfo.Description;
			updateUserDto.Email = userInfo.Email;
            return View(updateUserDto);
		}

		[HttpPost]
		public IActionResult UpdateUserl ()
		{
			return View();
		}
	}
}
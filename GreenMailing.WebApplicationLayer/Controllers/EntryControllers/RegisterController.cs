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
		UpdateUserValidator _updateUserValidator = new();
        public RegisterController(IUserService userService, CreateUserValidator createUserValidator, UserManager<User> userManager, UpdateUserValidator updateUserValidator)
        {
            _userService = userService;
            _createUserValidator = createUserValidator;
            _userManager = userManager;
            _updateUserValidator = updateUserValidator;
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
		public async Task<IActionResult> UpdateUser(int id)
		{
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userInfo = _userService.Get(x => x.Id == id);
			UpdateUserDto updateUserDto = new();
			//updateUserDto.Id = user.Id;
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
		public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
		{
			var validate = _updateUserValidator.Validate(updateUserDto);
			if (validate.IsValid) 
			{
                //var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var user = _userService.Get(x => x.Id == updateUserDto.Id);
                user.FirstName = updateUserDto.FirstName;
                user.LastName = updateUserDto.LastName;
                user.UserName = updateUserDto.UserName;
                user.Image = updateUserDto.Image;
                user.PhoneNumber = updateUserDto.PhoneNumber;
                user.Description = updateUserDto.Description;
                user.Email = updateUserDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, updateUserDto.Password);
                var updateUser = await _userManager.UpdateAsync(user);
                if (updateUser.Succeeded)
                {
                    return RedirectToAction("Index", "LogIn");
                }
            }			
			return View(updateUserDto);
		}
	}
}
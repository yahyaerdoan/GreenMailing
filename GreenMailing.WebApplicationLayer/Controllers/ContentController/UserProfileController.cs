using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;


        public UserProfileController(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userInfo = _userService.Get(x=> x.Id == user.Id);
            ViewBag.a = userInfo;
            return View(userInfo);
        }
    }
}
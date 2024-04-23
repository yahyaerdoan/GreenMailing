using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.ViewComponents
{
    public class _UserDetailsComponentPartial : ViewComponent
    {
        private readonly UserManager<User> _userManager;

		public _UserDetailsComponentPartial(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = user.FirstName + " " + user.LastName;
            return View();
        }
    }
}
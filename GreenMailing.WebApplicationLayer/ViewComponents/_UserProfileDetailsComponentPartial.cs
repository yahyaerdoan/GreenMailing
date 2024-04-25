using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.ViewComponents
{
    public class _UserProfileDetailsComponentPartial : ViewComponent
    {
        private readonly UserManager<User> _userManager;

		public _UserProfileDetailsComponentPartial(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.UserProfileDetailFullName = user.FirstName + " " + user.LastName;
			ViewBag.UserProfileDetailEmail = user.Email;
			ViewBag.UserProfileDetailId= user.Id;
			return View(user);
        }
    }
}
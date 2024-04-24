using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class SentMailController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;

        public SentMailController(UserManager<User> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }
        #region GetCurrentUserInfo
        public async Task<User> GetCurrentUserInfo()
        {
            User userInfo = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userInfo == null)
            {
                ModelState.AddModelError("", "User info not found");
            }
            return userInfo;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            var userInfo = await GetCurrentUserInfo();
            var values = _messageService.GetMessageListWithRecever(userInfo.Email);
            return View(values);
        }
    }
}

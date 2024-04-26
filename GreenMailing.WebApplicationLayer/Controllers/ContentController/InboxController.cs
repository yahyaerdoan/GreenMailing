using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class InboxController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;

        public InboxController(IMessageService messageService, UserManager<User> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
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
            var values = _messageService.GetMessageListWithSender(userInfo.Email);
            return View(values);
        }

        public async Task<IActionResult> GetIsImportantMessages()
        {
            var userInfo = await GetCurrentUserInfo();
            var values = _messageService.GetIsImportantMessagesAndCountWithReceiver(userInfo.Email);
            return View("Index",values.isImportantMessages);
        }

        public async Task<IActionResult> GetIsStarredMessages()
        {
            var userInfo = await GetCurrentUserInfo();
            var values = _messageService.GetIsStarredMessagesAndCountWithReceiver(userInfo.Email);
            return View("Index", values.isStarredMessages);
        }
    }
}
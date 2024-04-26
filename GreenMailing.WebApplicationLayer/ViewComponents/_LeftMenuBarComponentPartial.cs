using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.ViewComponents
{
    public class _LeftMenuBarComponentPartial : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;

        public _LeftMenuBarComponentPartial(IMessageService messageService, UserManager<User> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        #region GetCurrentUserInfo
        public async Task<User?> GetCurrentUserInfo()
        {
            User userInfo = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (userInfo == null)
            {
                ModelState.AddModelError("", "User info not found");
            }
            return userInfo;
        }
        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userInfo = await GetCurrentUserInfo();
            var UnReadMessagesCount = _messageService.GetUnReadMessagesCountWithRecever(userInfo.Email);
            var isImportantMessagesCount = _messageService.GetIsImportantMessagesAndCountWithReceiver(userInfo.Email);
            ViewBag.IsImportantMessagesCount = isImportantMessagesCount.count;
            ViewBag.UnReadMessagesCount = UnReadMessagesCount;
            return View();
        }
    }
}
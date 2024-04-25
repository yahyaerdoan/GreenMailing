using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class ComposeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageService;

        public ComposeController(IMessageService messageService, UserManager<User> userManager)
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Message message)
        {
            var userInfo = await GetCurrentUserInfo();
            message.UserId = userInfo.Id;
            message.Sender = userInfo.Email;
            message.Timestamp = DateTime.Now;
            message.Status = true;
            message.IsRead = false;
            message.IsTrash = false;
            message.IsImportant = false;
            message.IsStarred = false;
            _messageService.Add(message);
            return RedirectToAction("Index", "SentMail");
        }
    }
}
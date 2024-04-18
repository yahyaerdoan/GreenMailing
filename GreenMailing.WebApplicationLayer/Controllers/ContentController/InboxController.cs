using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class InboxController : Controller
    {
        private readonly IMessageService _messageService;

        public InboxController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values = _messageService.GetAll();
            return View(values);
        }
    }
}

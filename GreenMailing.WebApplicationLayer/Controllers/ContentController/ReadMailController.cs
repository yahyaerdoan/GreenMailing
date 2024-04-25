using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GreenMailing.WebApplicationLayer.Controllers.ContentController
{
    public class ReadMailController : Controller
    {
        private readonly IMessageService _messageService;

        public ReadMailController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index(int id)
        {
            var values = _messageService.Get(x => x.MessageId == id);
            return View(values);
        }
    }
}

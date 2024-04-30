using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.DataAccessLayer.Concrete.Context;
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
            _messageService.ChangeIsReadStatusToTrue(id);
            var values = _messageService.GetMessageByIdWithSender(id);
            return View(values);
        }
        public IActionResult ChangeIsReadStatusToTrue(int id)
        {
            _messageService.ChangeIsReadStatusToTrue(id);
            return RedirectToAction("Index", "Inbox");
        }
        public IActionResult ChangeIsImportantStatusToTrue(int id)
        {
            _messageService.ChangeIsImportantStatusToTrue(id);
            return RedirectToAction("Index", "Inbox");
        }

        public IActionResult ChangeIsStarredStatusToTrue(int id)
        {
            _messageService.ChangeIsStarredStatusToTrue(id);
            return RedirectToAction("Index", "Inbox");
        }
        #region These are not using

        public IActionResult ChangeIsTrashStatusToTrue(List<int> selectedItems)
        {

            if (selectedItems != null && selectedItems.Count > 0)
            {
                _messageService.ChangeIsTrashStatusToTrue(selectedItems);
            }
            return RedirectToAction("Index", "Inbox");
        }

        public IActionResult DeleteIsTrashStatusTrueMessage(List<int> selectedItems)
        {
            if (selectedItems != null && selectedItems.Count > 0)
            {
                _messageService.DeleteIsTrashStatusTrueMessage(selectedItems);
            }
            return RedirectToAction("Index", "Inbox");
        }
        #endregion
        public IActionResult ChangeIsTrashStatusToTrueAndDeleteIsTrashStatusTrueMessage(List<int> selectedItems)
        {
            if (selectedItems != null && selectedItems.Any())
            {
                var firstMessage = _messageService.GetMessageByIdWithSender(selectedItems.First());
                if (firstMessage != null)
                {
                    if (firstMessage.IsTrash == false)
                    {
                        _messageService.ChangeIsTrashStatusToTrue(selectedItems);
                    }
                    else
                    {
                        _messageService.DeleteIsTrashStatusTrueMessage(selectedItems);
                    }
                }
            }
            return RedirectToAction("Index", "Inbox");
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.ViewComponents
{
    public class _ScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}

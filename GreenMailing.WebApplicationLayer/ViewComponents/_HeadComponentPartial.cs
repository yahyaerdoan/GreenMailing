﻿using Microsoft.AspNetCore.Mvc;

namespace GreenMailing.WebApplicationLayer.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.UIViewComponent
{
	public class _UISliderViewComponentPartial:ViewComponent
	{
        MenuContext context = new MenuContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Sliders.ToList();
            return View(values);
        }
    }
}


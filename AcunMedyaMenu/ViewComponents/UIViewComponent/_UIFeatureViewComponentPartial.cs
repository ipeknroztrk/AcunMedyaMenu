using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.UIViewComponent
{
	public class _UIFeatureViewComponentPartial:ViewComponent
	{
        MenuContext context = new MenuContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Features.ToList();
            return View(values);
        }
    }
}


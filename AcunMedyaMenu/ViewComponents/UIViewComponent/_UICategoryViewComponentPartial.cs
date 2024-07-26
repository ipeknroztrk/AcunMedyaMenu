using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.UIViewComponent
{
	public class _UICategoryViewComponentPartial:ViewComponent
	{
        MenuContext context = new MenuContext();
        public IViewComponentResult Invoke()
		{
            var values = context.Categories.ToList();
            return View(values);
            
		}
	}
}


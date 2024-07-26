using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents
{
	public class _ChefListComponentPartial:ViewComponent
	{
        MenuContext context = new MenuContext();
        public IViewComponentResult Invoke()
        {
            var values = context.chefs.Where(x=>x.Status==true).ToList();
            return View(values);
        }
    }
}


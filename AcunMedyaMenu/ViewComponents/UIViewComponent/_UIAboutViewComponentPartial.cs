using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.UIViewComponent
{
	public class _UIAboutViewComponentPartial:ViewComponent
	{
		private readonly MenuContext _context;

        public _UIAboutViewComponentPartial(MenuContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
		{
			var values = _context.Abouts.ToList();
			return View(values);
		}
	}
}


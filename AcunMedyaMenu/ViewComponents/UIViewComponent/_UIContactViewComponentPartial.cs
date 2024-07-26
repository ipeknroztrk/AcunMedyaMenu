using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.UIViewComponent
{
	public class _UIContactViewComponentPartial:ViewComponent
	{
		private readonly MenuContext _context;

        public _UIContactViewComponentPartial(MenuContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
		{
			var values = _context.SocialMedias.ToList();
			return View(values);
		}
	}
}


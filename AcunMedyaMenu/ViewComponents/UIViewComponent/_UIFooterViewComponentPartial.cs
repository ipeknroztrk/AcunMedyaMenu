using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.UIViewComponent
{
	public class _UIFooterViewComponentPartial:ViewComponent
	{

		private readonly MenuContext _context;

        public _UIFooterViewComponentPartial(MenuContext context)
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


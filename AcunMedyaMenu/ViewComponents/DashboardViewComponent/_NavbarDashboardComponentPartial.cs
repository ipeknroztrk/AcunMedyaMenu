using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.DashboardViewComponent
{
	public class _NavbarDashboardComponentPartial:ViewComponent
	{
		private readonly MenuContext _context;

        public _NavbarDashboardComponentPartial(MenuContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
		{
			var values = _context.Messages.ToList();
			
			return View(values);
		}
	}
}


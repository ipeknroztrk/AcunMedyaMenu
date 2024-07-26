using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.UIViewComponent
{
	public class _UITestimonialViewComponentPartial:ViewComponent
	{
		private readonly MenuContext _context;

        public _UITestimonialViewComponentPartial(MenuContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
		{
			var values = _context.Testimonials.ToList();
			return View(values);
		}
	}
}


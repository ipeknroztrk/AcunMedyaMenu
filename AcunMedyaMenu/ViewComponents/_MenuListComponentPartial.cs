// _MenuListComponentPartial.cshtml.cs

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcunMedyaMenu.Context;
using AcunMedyaMenu.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaMenu.ViewComponents
{
    public class _MenuListComponentPartial : ViewComponent
    {
        private readonly MenuContext _context;

        public _MenuListComponentPartial(MenuContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<Product> products = await _context.products
                .Include(p => p.Category)
                .ToListAsync();

            return View(products);
        }
    }
}

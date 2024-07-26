using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcunMedyaMenu.Controllers
{
    public class ReservationController : Controller
    {
        private readonly MenuContext _context;

        public ReservationController(MenuContext context)
        {
            _context = context;
        }

        public IActionResult ReservationList()
        {
            var values = _context.Bookings.ToList();
            return View(values);
        }
    }
}


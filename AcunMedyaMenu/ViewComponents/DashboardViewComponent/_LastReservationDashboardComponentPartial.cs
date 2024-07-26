using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcunMedyaMenu.ViewComponents.DashboardViewComponents
{
    public class _LastReservationDashboardComponentPartial : ViewComponent
    {
        private readonly MenuContext _context;

        public _LastReservationDashboardComponentPartial(MenuContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            
            var lastFiveReservations = _context.Bookings
                .OrderByDescending(b => b.BookingDate) 
                .Take(4)
                .ToList();

            return View(lastFiveReservations);
        }
    }
}

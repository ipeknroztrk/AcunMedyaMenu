using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.ViewComponents.DashboardViewComponents
{
    public class _StatisticsDashboardComponentPartial : ViewComponent
    {
        MenuContext context = new MenuContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.productCount = context.products.Count();
            ViewBag.activeProductCount = context.products.Where(x => x.Status == true).Count();
            ViewBag.avgProductPrice = context.products.Average(x => x.Price);

           
            ViewBag.bookingCount = context.Bookings.Count();
            return View();
        }
    }
}
using System;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaMenu.ViewComponents.DashboardViewComponent
{
	public class _ChartDashboardComponentPartial:ViewComponent
	{
		private readonly MenuContext _context;

        public _ChartDashboardComponentPartial(MenuContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var oneYearAgo = DateTime.UtcNow.AddYears(-1);

            // Son 1 yıldaki rezervasyonları al
            var totalBookingsLastYear = await _context.Bookings
                .Where(x => x.BookingDate >= oneYearAgo)
                .CountAsync();

            // Yüzdelik değişim hesaplama - Örnek değer
            var percentageChange = 14; // Dinamik hesaplamaya bağlı olarak değişebilir

            // ViewBag verilerini ayarla
            ViewBag.TotalBookingsLastYear = totalBookingsLastYear;
            ViewBag.PercentageChange = percentageChange;


            // Toplam sipariş tutarını hesapla
            var totalOrderAmount = await _context.Orders
                .SumAsync(o => o.TotalPrice);

            // ViewBag verilerini ayarla
            
            ViewBag.TotalOrder = totalOrderAmount;

            return View();
		}
	}
}


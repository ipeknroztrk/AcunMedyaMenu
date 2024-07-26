using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcunMedyaMenu.Context;
using AcunMedyaMenu.Entities;
using Microsoft.AspNetCore.Mvc;


namespace AcunMedyaMenu.Controllers
{
    public class DefaultController : Controller
    {
        MenuContext context = new MenuContext();
        public IActionResult Index()
        {
            ViewBag.p1 = "250 yıllık sırlarla dolu özel odamıza hoşgeldiniz. Burası AcunMedya bir odaya sığan kocaman dostluklar, kutlamalar, özel anlaşmalar ve davetleri için Olden tutkunlarına açıldı. Eski bir hikayede yeni uzun sofralar kurmak için rezervasyon yaptırmanız yeterli.";
            ViewBag.p2 = "Deneyimli mutfak ekibimiz ve şık atmosferimizle unutulmaz bir yemek deneyimi için sizi bekliyoruz. Günün her saati için özel olarak hazırladığımız çeşitli menü seçenekleri ve özel etkinlik paketlerimizle size en iyisini sunmak için buradayız. Kahvaltı, öğle yemeği veya akşam yemeği için rezervasyon yaparken, unutulmaz lezzetlerle dolu bir deneyim vadeden menülerimizi keşfedin. Ayrıca özel etkinlikleriniz için de bize ulaşabilir, unutulmaz anlarınıza unutulmaz lezzetler katabiliriz. Bizimle iletişime geçin ve rezervasyonunuzu şimdiden yapın, sizleri ağırlamaktan mutluluk duyarız!";

            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
       
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }



        [HttpGet]
        public PartialViewResult CreateBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            booking.BookingDate = DateTime.UtcNow;
            booking.Description = "Rezervasyon Alındı.";

            context.Bookings.Add(booking);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Rezervasyon basariyla olusturuldu.";

            return RedirectToAction("Index", "Default");
        }



    }
}


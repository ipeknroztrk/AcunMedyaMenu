using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcunMedyaMenu.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaMenu.Controllers
{
    public class StatisticController : Controller
    {
        private readonly MenuContext _context;

        public StatisticController(MenuContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            ViewBag.productCount = _context.products.Count();
            ViewBag.activeProductCount = _context.products.Where(x => x.Status == true).Count();
            ViewBag.avgProductPrice = _context.products.Average(x => x.Price);
            ViewBag.Chefcount = _context.chefs.Count();
            ViewBag.activechefs = _context.chefs.Where(x => x.Status == true).Count();
            ViewBag.testimonialcount = _context.Testimonials.Count();
            ViewBag.message = _context.Messages.Count();
            ViewBag.category = _context.Categories.Count();
            ViewBag.socialmedia = _context.SocialMedias.Count();

           
            ViewBag.orders = _context.Orders.Count();

            ViewBag.orderswTotalPrice = _context.Orders.Sum(o => o.TotalPrice);
            ViewBag.ordersw = Math.Round(_context.Orders.Sum(o => o.TotalPrice) / 7);






            return View();
        }
    }
}


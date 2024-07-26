using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcunMedyaMenu.Context;
using AcunMedyaMenu.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcunMedyaMenu.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly MenuContext _context;

        public AdminPanelController(MenuContext context)
        {
            _context = context;
        }


        //SLİDER

        public IActionResult SliderList()
        {
            var values = _context.Sliders.ToList();
            return View(values);
        }
        [HttpGet] 
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult CreateSlider(Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("SliderList");
        }
        public IActionResult DeleteSlider(int id)
        {
            var value = _context.Sliders.Find(id);
            _context.Sliders.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public IActionResult UpdateSlider(int id)
        {
            var value = _context.Sliders.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSlider(Slider slider)
        {
            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return RedirectToAction("SliderList");
        }




    }
}


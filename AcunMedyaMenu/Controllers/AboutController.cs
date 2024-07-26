using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcunMedyaMenu.Context;
using AcunMedyaMenu.Entities;
using Microsoft.AspNetCore.Mvc;


namespace AcunMedyaMenu.Controllers
{
    public class AboutController : Controller
    {
        private readonly MenuContext _context;

        public AboutController(MenuContext context)
        {
            _context = context;
        }

        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            var existingAbout = _context.Abouts.FirstOrDefault(a => a.AboutId == about.AboutId);

            if (existingAbout != null)
            {
                existingAbout.Title = about.Title;
                existingAbout.Description = about.Description;
                existingAbout.ImageUrl = about.ImageUrl;
                existingAbout.VideoUrl = about.VideoUrl;

                _context.Abouts.Update(existingAbout);
                _context.SaveChanges();
            }

            return RedirectToAction("AboutList");
        }

    }
}


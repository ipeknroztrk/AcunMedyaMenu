using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcunMedyaMenu.Context;
using AcunMedyaMenu.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcunMedyaMenu.Controllers
{
    public class ChefController : Controller
    {

        private readonly MenuContext _context;

        public ChefController(MenuContext context)
        {
            _context = context;
        }


        //SLİDER

        public IActionResult ChefList()
        {
            var values = _context.chefs.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.chefs.Add(chef);
            _context.SaveChanges();
            return RedirectToAction("ChefList");
        }

        [HttpPost]
        public IActionResult DeleteChef(int chefId)
        {
            var chef = _context.chefs.Find(chefId);

            if (chef == null)
            {
                return NotFound(); // Handle case where chef with given id is not found
            }

            _context.chefs.Remove(chef);
            _context.SaveChanges();

            return RedirectToAction("ChefList");
        }


        [HttpGet]
        public IActionResult UpdateChef(int chefId)
        {
            var chef = _context.chefs.Find(chefId);

            if (chef == null)
            {
                return NotFound(); // Şef bulunamadığında işlemleri yönet
            }

            return View(chef);
        }

        [HttpPost]
public IActionResult UpdateChef(Chef chef)
{
    if (!ModelState.IsValid)
    {
        return View(chef); // Model durumu geçerli değilse hataları ile birlikte görünümü göster
    }

    var existingChef = _context.chefs.Find(chef.ChefId);
    
    if (existingChef == null)
    {
        return NotFound(); // Şef bulunamadığında işlemleri yönet
    }
    
    existingChef.ChefName = chef.ChefName;
    existingChef.Title = chef.Title;
    existingChef.ImageUrl = chef.ImageUrl;
    existingChef.Status = chef.Status;

    _context.SaveChanges();
    return RedirectToAction("ChefList");
}

        [HttpPost]
        public IActionResult ActivateChef(int chefId)
        {
            var chef = _context.chefs.Find(chefId);
            if (chef != null)
            {
                chef.Status = true;
                _context.SaveChanges();
            }
            return RedirectToAction("ChefList");
        }

        [HttpPost]
        public IActionResult DeactivateChef(int chefId)
        {
            var chef = _context.chefs.Find(chefId);
            if (chef != null)
            {
                chef.Status = false;
                _context.SaveChanges();
            }
            return RedirectToAction("ChefList");
        }

    }
}


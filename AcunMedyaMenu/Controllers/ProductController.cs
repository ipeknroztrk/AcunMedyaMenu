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
    public class ProductController : Controller
    {
        private readonly MenuContext _context;

        public ProductController(MenuContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            var productsByCategory = _context.products.Include(p => p.Category).OrderBy(p => p.Category.CategoryName).ToList();
            return View(productsByCategory);
        }
        [HttpPost]
        public IActionResult ToggleStatus(int productId)
        {
            var product = _context.products.Find(productId);

            if (product == null)
            {
                return NotFound();
            }

            product.Status = (product.Status == true) ? false : true;
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }


        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.products.Find(id);
            _context.products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var product = _context.products.Find(id);


            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("ProductList");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return RedirectToAction("ProductList");
        }

    }
}


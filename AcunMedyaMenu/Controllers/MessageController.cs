using System;
using Microsoft.AspNetCore.Mvc;
using AcunMedyaMenu.Entities;
using AcunMedyaMenu.Context;

namespace AcunMedyaMenu.Controllers
{
    public class MessageController : Controller
    {
        private readonly MenuContext _context;

        public MessageController(MenuContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.DateSent = DateTime.UtcNow; 

                _context.Messages.Add(message);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Mesajiniz basariyla gonderildi!";
                ModelState.Clear();

                return RedirectToAction("Index","Default"); 
            }

           
            return View(nameof(Index), message);
        }
    }
}

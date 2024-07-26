using System;
using AcunMedyaMenu.Context;
using AcunMedyaMenu.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaMenu.Controllers
{
	public class SocialMediaController:Controller
	{
		private readonly MenuContext _context;

        public SocialMediaController(MenuContext context)
        {
            _context = context;
        }
        

        public IActionResult SocialMediaList()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            _context.SocialMedias.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                var existingSocialMedia = _context.SocialMedias.Find(socialMedia.SocialMediaId);
                if (existingSocialMedia == null)
                {
                    return NotFound();
                }

                existingSocialMedia.Name = socialMedia.Name;
                existingSocialMedia.Icon = socialMedia.Icon;
                existingSocialMedia.Url = socialMedia.Url;

                _context.SocialMedias.Update(existingSocialMedia);
                _context.SaveChanges();
                return RedirectToAction("SocialMediaList");
            }
            return View(socialMedia);
        }
    }
}


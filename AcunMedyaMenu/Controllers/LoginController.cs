using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcunMedyaMenu.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Login/Authenticate
        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            // Burada admin girişinin kontrolü yapılacak
            if (username == "ipek" && password == "123456")
            {
                // Admin girişi başarılı ise yönlendirme yapılabilir
                // Örneğin, admin paneline yönlendir
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                // Admin girişi başarısız ise hata mesajı gösterebilir
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
                return View("Index");
            }
        }
    }

}

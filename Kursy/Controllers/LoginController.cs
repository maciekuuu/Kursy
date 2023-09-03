using Kursy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kursy.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin admin)
        {
            // Sprawdź poprawność logowania
            if (admin.Login == "admin" && admin.Password == "password")
            {
                // Poprawne dane logowania
                // Przekieruj na stronę główną lub inny widok po zalogowaniu
                HttpContext.Session.SetString("AdminLoggedIn", "true");
                return RedirectToAction("Index", "Courses");
            }

            // Błędne dane logowania
            ModelState.AddModelError("", "Nieprawidłowy login lub hasło.");
            return View(admin);
        }
    }
}

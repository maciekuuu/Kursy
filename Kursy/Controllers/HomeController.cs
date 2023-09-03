using Kursy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kursy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("AdminLoggedIn", "false");
            var model = new HomeViewModel
            {
                LogoPath = "~/Images/logo.png",
                Courses = _context.Courses.Where(c=>c.Visible == true).ToList()
        };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Mail")] User user, int kursId)
        {
            //if (ModelState.IsValid)
            //{

                Course course = _context.Courses.FirstOrDefault(c => c.Id == kursId);

                if (course != null)
                {

                    user.Course = course;

                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            //}

            return View(user);
        }




    }
}
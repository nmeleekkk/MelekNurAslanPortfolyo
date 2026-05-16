using System.Diagnostics;
using MelekNurAslanPortfolyo.Models;
using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;

namespace MelekNurAslanPortfolyo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortfolioContext _context; //Veritabaný köprüsü

        public HomeController(ILogger<HomeController> logger, PortfolioContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Veritabanýndan projeleri çekip ön yüze yolluyoruz
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendMessage([FromForm] ContactMessage model)
        {
            ModelState.Remove("Id");
            ModelState.Remove("SendDate");

            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(model);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Mesajýnýz baþarýyla iletildi!";
                return RedirectToAction("Index");
            }

            var projects = _context.Projects.ToList();
            return View("Index", projects);
        }
    }
}
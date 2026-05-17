using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using Microsoft.AspNetCore.Authorization;

namespace MelekNurAslanPortfolyo.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ProjectCount = _context.Projects.Count();
            ViewBag.MessageCount = _context.ContactMessages.Count();

            ViewBag.SkillCount = 0;

            return View();
        }
    }
}
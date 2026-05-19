using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

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
            ViewBag.SkillCount = _context.Skills.Count();
            ViewBag.CertificateCount = _context.Certificates.Count();
            ViewBag.EducationCount = _context.Educations.Count();
            ViewBag.SocialMediaCount = _context.SocialMedias.Count();

            return View();
        }
    }
}
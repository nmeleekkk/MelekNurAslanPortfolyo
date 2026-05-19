using MelekNurAslanPortfolyo.Data;
using MelekNurAslanPortfolyo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MelekNurAslanPortfolyo.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;
        public EducationController(PortfolioContext context) { _context = context; }

        public IActionResult Index() => View(_context.Educations.ToList());

        [HttpGet] 
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _context.Educations.Find(id);
            if (value != null) { _context.Educations.Remove(value); _context.SaveChanges(); }
            return RedirectToAction("Index");
        }

        [HttpGet] public IActionResult Edit(int id) => View(_context.Educations.Find(id));

        [HttpPost]
        public IActionResult Edit(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
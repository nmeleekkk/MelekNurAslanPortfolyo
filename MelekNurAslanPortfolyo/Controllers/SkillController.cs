using MelekNurAslanPortfolyo.Data;
using MelekNurAslanPortfolyo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MelekNurAslanPortfolyo.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Skill skill, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(imageFile.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot/img/", imagename);

                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                skill.ImageUrl = "/img/" + imagename;
            }

            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _context.Skills.Find(id);
            if (value != null)
            {
                _context.Skills.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _context.Skills.Find(id);
            if (value == null)
            {
                return RedirectToAction("Index");
            }
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Skill skill, IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(imageFile.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot/img/", imagename);

                using (var stream = new FileStream(savelocation, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                skill.ImageUrl = "/img/" + imagename;
            }

            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
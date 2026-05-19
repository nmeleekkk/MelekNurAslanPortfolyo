using MelekNurAslanPortfolyo.Data;
using MelekNurAslanPortfolyo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MelekNurAslanPortfolyo.Controllers
{
    [Authorize]
    public class CertificateController : Controller
    {
        private readonly PortfolioContext _context;
        public CertificateController(PortfolioContext context) { _context = context; }

        public IActionResult Index() => View(_context.Certificates.ToList());

        [HttpGet] public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Certificate certificate, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(imageFile.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot/img/", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create)) { await imageFile.CopyToAsync(stream); }
                certificate.ImageUrl = "/img/" + imagename;
            }
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _context.Certificates.Find(id);
            if (value != null) { _context.Certificates.Remove(value); _context.SaveChanges(); }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _context.Certificates.Find(id);
            if (value == null) return RedirectToAction("Index");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Certificate certificate, IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(imageFile.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = Path.Combine(resource, "wwwroot/img/", imagename);
                using (var stream = new FileStream(savelocation, FileMode.Create)) { await imageFile.CopyToAsync(stream); }
                certificate.ImageUrl = "/img/" + imagename;
            }

            _context.Certificates.Update(certificate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using MelekNurAslanPortfolyo.Models;
using Microsoft.AspNetCore.Authorization;

namespace MelekNurAslanPortfolyo.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();

            if (about == null)
            {
                about = new About 
                { 
                    Title = "Başlık", 
                    SubTitle = "Alt Başlık", 
                    Description = "Hikayeniz..." 
                };
            }

            return View(about);
        }

        [HttpPost]
        public IActionResult Update(About model, IFormFile? imageFile, IFormFile? backgroundImageFile)
        {
            ModelState.Remove("ImageUrl");
            ModelState.Remove("BackgroundImageUrl");

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                model.ImageUrl = "/img/" + fileName;
            }

            if (backgroundImageFile != null && backgroundImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(backgroundImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    backgroundImageFile.CopyTo(stream);
                }
                model.BackgroundImageUrl = "/img/" + fileName;
            }

            if (model.Id == 0)
            {
                _context.Abouts.Add(model);
            }
            else
            {
                _context.Abouts.Update(model);
            }

            _context.SaveChanges();
            TempData["SuccessMessage"] = "Hakkımda bilgileri başarıyla güncellendi!";
            return RedirectToAction("Index");
        }
    }
}
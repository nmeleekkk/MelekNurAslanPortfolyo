using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MelekNurAslanPortfolyo.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // Veritabanı köprümüzü tanımlıyoruz
        private readonly PortfolioContext _context;

        // Controller çalıştığında veritabanı bağlantısı otomatik içeri alınır
        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }

        // Listeleme sayfamız
        public IActionResult Index()
        {
            // Veritabanındaki Projects tablosundaki tüm kayıtları listeye çevir
            var projects = _context.Projects.ToList();

            return View(projects);
        }

        // GET: Formu ekrana getiren kısım
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formdan gelen verileri veritabanına kaydeden kısım
        [HttpPost]
        public IActionResult Create(MelekNurAslanPortfolyo.Models.Project project, IFormFile imageFile)
        {
            ModelState.Remove("ImageUrl");

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                project.ImageUrl = "/img/" + fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Güncellenecek veriyi bulup formu dolu getiren kısım
        public IActionResult Edit(int id)
        {
            // Veritabanından o ID'ye sahip projeyi bul
            var project = _context.Projects.Find(id);

            // Eğer o ID'de bir proje yoksa hata sayfası göster
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Değiştirilen verileri kaydeden kısım
        [HttpPost]
        public IActionResult Edit(MelekNurAslanPortfolyo.Models.Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Update(project); // Projeyi güncelle
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Silinecek projeyi bulup "Emin misin?" onay sayfasına gönderen kısım
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Onay verildikten sonra projeyi gerçekten veritabanından silen kısım
        [HttpPost, ActionName("Delete")] 
        public IActionResult DeleteConfirmed(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project); // Projeyi sil
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
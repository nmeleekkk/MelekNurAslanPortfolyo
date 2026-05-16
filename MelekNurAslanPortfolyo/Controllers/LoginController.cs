using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using MelekNurAslanPortfolyo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MelekNurAslanPortfolyo.Controllers
{
    public class LoginController : Controller
    {
        private readonly PortfolioContext _context;

        public LoginController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: Sadece giriş formunu ekrana getirir
        public IActionResult Index()
        {
            return View();
        }

        // POST: Butona basıldığında şifre kontrolü yapar
        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            // Veritabanında formdan gelen kullanıcı adı ve şifreyle eşleşen biri var mı?
            var bilgiler = _context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, bilgiler.Username)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Project");
            }

            return View();
        }

        // Çıkış Yapma İşlemi
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }
    }
}
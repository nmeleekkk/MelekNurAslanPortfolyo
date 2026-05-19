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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            var bilgiler = _context.Admins.FirstOrDefault(x => x.Username == admin.Username);

            if (bilgiler != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(admin.Password, bilgiler.Password);

                if (isPasswordValid)
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
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public string GenerateHash(string myPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(myPassword);
        }
    }
}
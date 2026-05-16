using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using Microsoft.AspNetCore.Authorization;

namespace MelekNurAslanPortfolyo.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;
        public MessageController(PortfolioContext context) { _context = context; }

        public IActionResult Index()
        {
            var messages = _context.ContactMessages.OrderByDescending(x => x.SendDate).ToList();
            return View(messages);
        }
    }
}
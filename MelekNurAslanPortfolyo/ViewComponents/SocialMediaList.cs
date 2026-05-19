using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using System.Linq;

namespace MelekNurAslanPortfolyo.ViewComponents
{
    public class SocialMediaList : ViewComponent
    {
        private readonly PortfolioContext _context;

        public SocialMediaList(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.SocialMedias.Where(x => x.Status == true).ToList();
            return View(values);
        }
    }
}
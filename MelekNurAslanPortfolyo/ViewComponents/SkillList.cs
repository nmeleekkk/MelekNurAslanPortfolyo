using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using System.Linq;

namespace MelekNurAslanPortfolyo.ViewComponents
{
    public class SkillList : ViewComponent
    {
        private readonly PortfolioContext _context;

        public SkillList(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }
    }
}
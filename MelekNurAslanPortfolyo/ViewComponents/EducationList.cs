using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using System.Linq;

namespace MelekNurAslanPortfolyo.ViewComponents
{
    public class EducationList : ViewComponent
    {
        private readonly PortfolioContext _db;

        public EducationList(PortfolioContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var values = _db.Educations.OrderBy(x => x.Id).ToList();
            return View(values);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MelekNurAslanPortfolyo.Data;
using System.Linq;

namespace MelekNurAslanPortfolyo.ViewComponents
{
    public class CertificateList : ViewComponent
    {
        private readonly PortfolioContext _context;

        public CertificateList(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Certificates.ToList();
            return View(values);
        }
    }
}
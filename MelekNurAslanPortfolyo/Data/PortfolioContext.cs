using Microsoft.EntityFrameworkCore;
using MelekNurAslanPortfolyo.Models; // Project sınıfını tanıyabilmesi için

namespace MelekNurAslanPortfolyo.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<About> Abouts { get; set; }
    }
}
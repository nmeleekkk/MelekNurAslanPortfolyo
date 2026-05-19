using System.ComponentModel.DataAnnotations;

namespace MelekNurAslanPortfolyo.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
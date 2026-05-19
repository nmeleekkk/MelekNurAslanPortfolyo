using System.ComponentModel.DataAnnotations;

namespace MelekNurAslanPortfolyo.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProficiencyValue { get; set; }
        public string? ImageUrl { get; set; }
    }
}
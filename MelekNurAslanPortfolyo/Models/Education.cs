using System.ComponentModel.DataAnnotations;

namespace MelekNurAslanPortfolyo.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string? SchoolName { get; set; }
        public string? Department { get; set; }
        public string? Years { get; set; }
        public string? Description { get; set; }
    }
}
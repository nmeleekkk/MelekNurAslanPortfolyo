using System.ComponentModel.DataAnnotations;

namespace MelekNurAslanPortfolyo.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        public string Url { get; set; }
        public string? Icon { get; set; }
        public bool Status { get; set; }
    }
}
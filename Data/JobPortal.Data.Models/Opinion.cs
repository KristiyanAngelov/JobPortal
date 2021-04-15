using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Models
{
    public class Opinion
    {
        [Required]
        public string WorkerId { get; set; }

        public Worker Worker { get; set; }

        [Required]
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public string Text { get; set; }
    }
}

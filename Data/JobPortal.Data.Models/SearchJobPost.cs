namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Common.Models;

    public class SearchJobPost : BaseDeletableModel<string>
    {
        [Required]
        public string Positions { get; set; }

        [Required]
        public string JobTypes { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string WorkerId { get; set; }

        public Worker Worker { get; set; }
    }
}

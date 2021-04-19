namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Common.Models;
    using JobPortal.Data.Models.Enums;

    public class SearchJobPost : BaseDeletableModel<string>
    {
        [Required]
        public string Positions { get; set; }

        [Required]
        public JobType JobType { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string WorkerId { get; set; }

        public Worker Worker { get; set; }
    }
}

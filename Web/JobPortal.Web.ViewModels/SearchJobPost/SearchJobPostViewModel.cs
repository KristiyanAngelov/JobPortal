namespace JobPortal.Web.ViewModels.SearchJobPost
{
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Models;
    using JobPortal.Data.Models.Enums;
    using JobPortal.Services.Mapping;

    public class SearchJobPostViewModel : IMapFrom<SearchJobPost>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Positions { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public JobType JobType { get; set; }

        [Required]
        public Worker Worker { get; set; }
    }
}

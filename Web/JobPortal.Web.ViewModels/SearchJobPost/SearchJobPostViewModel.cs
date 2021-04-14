namespace JobPortal.Web.ViewModels.SearchJobPost
{
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Models;
    using JobPortal.Services.Mapping;

    public class SearchJobPostViewModel : IMapFrom<SearchJobPostViewModel>
    {
        [Required]
        public string Positions { get; set; }

        [Required]
        public string JobTypes { get; set; }

        [Required]
        public Worker Worker { get; set; }
    }
}

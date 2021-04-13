namespace JobPortal.Web.ViewModels.JobPost
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Models;
    using JobPortal.Services.Mapping;

    public class JobPostViewModel : IMapFrom<JobPost>
    {
        [Required]
        public string PositionName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyDescription { get; set; }

        [Required]
        public string JobResponsibilities { get; set; }

        [Required]
        public string JobRequirements { get; set; }

        [Required]
        public string Benefits { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
namespace JobPortal.Web.ViewModels.JobPost
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using JobPortal.Data.Models.Enums;
    using JobPortal.Services.Mapping;

    public class JobPostCreateViewModel : IMapTo<JobPostCreateInputModel>
    {
        [Required]
        [MaxLength(50)]
        public string PositionName { get; set; }

        [Required]
        public string CompanyDescription { get; set; }

        [Required]
        public string JobResponsibilities { get; set; }

        [Required]
        public string JobRequirements { get; set; }

        [Required]
        public JobType JobType { get; set; }

        [Required]
        public string CompanyLogo { get; set; }

        [Required]
        public string Benefits { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

    }
}

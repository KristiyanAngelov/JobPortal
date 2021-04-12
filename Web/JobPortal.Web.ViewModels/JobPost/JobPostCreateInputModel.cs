namespace JobPortal.Web.ViewModels.JobPost
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Models;
    using JobPortal.Services.Mapping;

    public class JobPostCreateInputModel : IMapTo<JobPost>
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
        public string Benefits { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string CompanyId { get; set; }

    }
}

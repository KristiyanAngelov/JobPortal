namespace JobPortal.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Common.Models;

    public class JobPost : BaseDeletableModel<string>
    {
        public JobPost()
        {
            this.Candidates = new HashSet<WorkerJobPost>();
        }

        [Required]
        [MaxLength(50)]
        public string PositionName { get; set; }

        [Required]
        public string CompanyDescription { get; set; }

        [Required]
        public string CompanyLogo { get; set; }

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
        [MaxLength(50)]
        public string Location { get; set; }

        public virtual ICollection<WorkerJobPost> Candidates { get; set; }

        [Required]
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}

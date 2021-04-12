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

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(50)]
        public string PositionName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string CompanyDescription { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string JobResponsibilities { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string JobRequirements { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Benefits { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime ApplicationDate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime StartingDate { get; set; }

        public virtual ICollection<WorkerJobPost> Candidates { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}

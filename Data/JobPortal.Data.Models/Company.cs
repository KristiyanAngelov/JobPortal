namespace JobPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company : ApplicationUser
    {
        public Company()
        {
            this.JobPostings = new HashSet<JobPost>();
        }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Logo { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string WebSite { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<JobPost> JobPostings { get; set; }
    }
}

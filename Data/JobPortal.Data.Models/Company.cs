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

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        public string WebSite { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<JobPost> JobPostings { get; set; }
    }
}

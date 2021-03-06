namespace JobPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company : ApplicationUser
    {
        public Company()
        {
            this.JobPostings = new HashSet<JobPost>();
            this.BlogPosts = new HashSet<BlogPost>();
            this.WorkersOpinions = new HashSet<Opinion>();
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

        public virtual ICollection<BlogPost> BlogPosts { get; set; }

        public virtual ICollection<Opinion> WorkersOpinions { get; set; }
    }
}

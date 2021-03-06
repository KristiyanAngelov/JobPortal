namespace JobPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Models.Enums;

    public class Worker : ApplicationUser
    {
        public Worker()
        {
            this.JobApplications = new HashSet<WorkerJobPost>();
            this.SearchJobPosts = new HashSet<SearchJobPost>();
            this.Opinions = new HashSet<Opinion>();
        }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public string WorkExperience { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        public string CV { get; set; }

        public string LinkedIn { get; set; }

        public string Github { get; set; }

        public virtual ICollection<WorkerJobPost> JobApplications { get; set; }

        public virtual ICollection<SearchJobPost> SearchJobPosts { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}

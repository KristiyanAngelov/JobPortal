namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WorkerJobPost
    {
        [Required]
        public string CandidateId { get; set; }

        public Worker Candidate { get; set; }

        [Required]
        public string JobPostId { get; set; }

        public JobPost JobPost { get; set; }
    }
}

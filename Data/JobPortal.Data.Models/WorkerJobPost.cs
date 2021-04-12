namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WorkerJobPost
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string CandidateId { get; set; }

        public Worker Candidate { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string JobPostId { get; set; }

        public JobPost JobPost { get; set; }
    }
}

namespace JobPortal.Data.Models
{
    using System.Collections.Generic;

    using JobPortal.Data.Models.Enums;

    public class Worker : ApplicationUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string LinkedIn { get; set; }

        public string Github { get; set; }

        public virtual ICollection<WorkerJobPost> JobApplications { get; set; }
    }
}

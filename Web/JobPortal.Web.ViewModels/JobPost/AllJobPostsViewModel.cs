namespace JobPortal.Web.ViewModels.JobPost
{
    using System.Collections.Generic;

    public class AllJobPostsViewModel
    {
        public ICollection<JobPostViewModel> JobPosts { get; set; }
    }
}

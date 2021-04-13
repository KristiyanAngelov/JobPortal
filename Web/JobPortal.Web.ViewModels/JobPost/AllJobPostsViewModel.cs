namespace JobPortal.Web.ViewModels.JobPost
{
    using System.Collections.Generic;
    using JobPortal.Data.Models;

    public class AllJobPostsViewModel
    {
        public ICollection<JobPost> JobPosts { get; set; }
    }
}

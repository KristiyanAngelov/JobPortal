namespace JobPortal.Web.ViewModels.SearchJobPost
{
    using System.Collections.Generic;

    public class AllSearchJobPostsViewModel
    {
        public ICollection<SearchJobPostViewModel> SearchJobPosts { get; set; }
    }
}

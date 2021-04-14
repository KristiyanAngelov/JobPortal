namespace JobPortal.Web.ViewModels.Blog
{
    using System.Collections.Generic;

    public class AllBlogPostsViewModel
    {
        public ICollection<BlogPostViewModel> BlogPosts { get; set; }
    }
}

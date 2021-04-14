namespace JobPortal.Web.ViewModels.Blog
{
    using System;

    using JobPortal.Data.Models;
    using JobPortal.Services.Mapping;

    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent { get; set; }

        public string ImageOrVideoUrl { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

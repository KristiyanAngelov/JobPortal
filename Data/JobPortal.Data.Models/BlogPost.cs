namespace JobPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Common.Models;

    public class BlogPost : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        [DataType(DataType.Html)]
        public string ShortContent { get; set; }

        public string ImageOrVideoUrl { get; set; }
    }
}

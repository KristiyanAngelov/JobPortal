namespace JobPortal.Web.ViewModels.Opinion
{
    using System.ComponentModel.DataAnnotations;

    using JobPortal.Data.Models;
    using JobPortal.Services.Mapping;

    public class CreateOpinionViewModel : IMapTo<Opinion>
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Text { get; set; }
    }
}

namespace JobPortal.Services.Data
{
    using System.Threading.Tasks;

    using JobPortal.Web.ViewModels.JobPost;

    public interface IJobPostsService
    {
        // CRUD
        Task<string> CreateAsync(JobPostCreateInputModel inputModel);
    }
}
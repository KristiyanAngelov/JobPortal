namespace JobPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JobPortal.Data.Models;
    using JobPortal.Web.ViewModels.JobPost;

    public interface IJobPostsService
    {
        // CRUD
        public Task<string> CreateAsync(JobPostCreateViewModel inputModel, string companyId);

        public Task AddCandidateAsync(string jobPostId, Worker candidate);

        public ICollection<T> GetAllJobPosts<T>();

        public ICollection<JobPost> GetAllJobPosts();

        public JobPost GetJobById(string jobId);

        public T GetJobById<T>(string jobId);
    }
}
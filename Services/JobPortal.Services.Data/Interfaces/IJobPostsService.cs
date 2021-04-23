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

        public ICollection<T> GetAll<T>();

        public ICollection<JobPost> GetAll();

        public JobPost GetById(string jobId);

        public T GetById<T>(string jobId);

        public ICollection<JobPost> GetAllCompanyJobPosts(string companyId);
    }
}

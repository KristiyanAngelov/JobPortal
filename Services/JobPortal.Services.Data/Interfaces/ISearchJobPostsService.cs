namespace JobPortal.Services.Data.Interfaces
{
    using JobPortal.Data.Models;
    using JobPortal.Data.Models.Enums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchJobPostsService
    {
        public Task<string> CreateAsync(string positions, JobType jobType, string workerId, string city);

        public ICollection<T> GetAllSearchJobPosts<T>();

        public ICollection<SearchJobPost> GetAllSearchJobPosts();

        public T GetSearchJobPostById<T>(string jobId);
    }
}

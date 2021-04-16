namespace JobPortal.Services.Data.Interfaces
{
    using JobPortal.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchJobPostsService
    {
        public Task<string> CreateAsync(string positions, string jobTypes, string workerId, string city);

        public ICollection<T> GetAllSearchJobPosts<T>();

        public ICollection<SearchJobPost> GetAllSearchJobPosts();

        public T GetSearchJobPostById<T>(string jobId);
    }
}

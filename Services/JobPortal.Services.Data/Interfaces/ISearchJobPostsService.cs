namespace JobPortal.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchJobPostsService
    {
        public Task<string> CreateAsync(string positions, string jobTypes, string workerId, string city);

        public ICollection<T> GetAllSearchJobPosts<T>();

        public T GetSearchJobPostById<T>(string jobId);
    }
}

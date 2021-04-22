namespace JobPortal.Services.Data.Interfaces
{
    using JobPortal.Data.Models;
    using JobPortal.Data.Models.Enums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISearchJobPostsService
    {
        public Task<string> CreateAsync(string positions, JobType jobType, string workerId, string city);

        public ICollection<T> GetAll<T>();

        public ICollection<SearchJobPost> GetAll();

        public T GetById<T>(string jobId);

        public SearchJobPost GetById(string jobId);
    }
}

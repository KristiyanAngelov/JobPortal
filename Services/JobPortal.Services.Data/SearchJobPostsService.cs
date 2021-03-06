namespace JobPortal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPortal.Data.Common.Repositories;
    using JobPortal.Data.Models;
    using JobPortal.Data.Models.Enums;
    using JobPortal.Services.Data.Interfaces;
    using JobPortal.Services.Mapping;

    public class SearchJobPostsService : ISearchJobPostsService
    {
        private readonly IRepository<SearchJobPost> searchJobPostsRepository;

        public SearchJobPostsService(IRepository<SearchJobPost> searchJobPostsRepository)
        {
            this.searchJobPostsRepository = searchJobPostsRepository;
        }

        public async Task<string> CreateAsync(string positions, JobType jobType, string workerId, string city)
        {
            var searchJobPost = new SearchJobPost
            {
                Id = Guid.NewGuid().ToString(),
                Positions = positions,
                JobType = jobType,
                WorkerId = workerId,
                City = city,
            };

            await this.searchJobPostsRepository.AddAsync(searchJobPost);
            await this.searchJobPostsRepository.SaveChangesAsync();

            return searchJobPost.Id;
        }

        public ICollection<T> GetAll<T>()
        {
            return this.searchJobPostsRepository
                 .All()
                 .To<T>()
                 .ToList();
        }

        public ICollection<SearchJobPost> GetAll()
        {
            return this.searchJobPostsRepository
                 .All()
                 .ToList();
        }

        public T GetById<T>(string searchJobPostId)
        {
            return this.searchJobPostsRepository
                .All()
                .Where(x => x.Id == searchJobPostId)
                .To<T>()
                .FirstOrDefault();
        }

        public SearchJobPost GetById(string searchJobPostId)
        {
            return this.searchJobPostsRepository
                .All()
                .FirstOrDefault(x => x.Id == searchJobPostId);
        }
    }
}

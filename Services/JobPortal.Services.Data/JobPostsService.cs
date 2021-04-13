namespace JobPortal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPortal.Data.Common.Repositories;
    using JobPortal.Data.Models;
    using JobPortal.Services.Mapping;
    using JobPortal.Web.ViewModels.JobPost;

    public class JobPostsService : IJobPostsService
    {
        private readonly IRepository<JobPost> jobPostsRepository;

        public JobPostsService(IRepository<JobPost> jobPostsRepository)
        {
            this.jobPostsRepository = jobPostsRepository;
        }

        public async Task<string> CreateAsync(JobPostCreateViewModel inputModel, string companyId)
        {
            var jobPost = new JobPost
            {
                Id = Guid.NewGuid().ToString(),
                CompanyLogo = inputModel.CompanyLogo,
                PositionName = inputModel.PositionName,
                CompanyDescription = inputModel.CompanyDescription,
                JobResponsibilities = inputModel.JobResponsibilities,
                JobRequirements = inputModel.JobRequirements,
                Benefits = inputModel.Benefits,
                ApplicationDate = inputModel.ApplicationDate,
                StartingDate = inputModel.StartingDate,
                Location = inputModel.Location,
                CompanyId = companyId,
            };

            await this.jobPostsRepository.AddAsync(jobPost);
            await this.jobPostsRepository.SaveChangesAsync();

            return jobPost.Id;
        }

        public ICollection<T> GetAllJobPosts<T>()
        {
            return this.jobPostsRepository
                .All()
                .To<T>()
                .ToList();
        }

        public T GetJobById<T>(string jobId)
        {
            return this.jobPostsRepository
                .All()
                .Where(x => x.Id == jobId)
                .To<T>()
                .FirstOrDefault();
        }
    }
}

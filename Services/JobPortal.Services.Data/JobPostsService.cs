namespace JobPortal.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using JobPortal.Data.Common.Repositories;
    using JobPortal.Data.Models;
    using JobPortal.Web.ViewModels.JobPost;

    public class JobPostsService : IJobPostsService
    {
        private readonly IDeletableEntityRepository<JobPost> jobPostsRepository;

        public JobPostsService(IDeletableEntityRepository<JobPost> jobPostsRepository)
        {
            this.jobPostsRepository = jobPostsRepository;
        }

        public async Task<string> CreateAsync(JobPostCreateViewModel inputModel, string companyId)
        {
            var jobPost = new JobPost
            {
                Id = Guid.NewGuid().ToString(),
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
    }
}

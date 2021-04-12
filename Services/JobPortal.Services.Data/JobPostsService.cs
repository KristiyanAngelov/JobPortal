namespace JobPortal.Services.Data
{
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

        public async Task<string> CreateAsync(JobPostCreateInputModel inputModel)
        {
            var jobPost = new JobPost
            {
                PositionName = inputModel.PositionName,
                CompanyDescription = inputModel.CompanyDescription,
                JobResponsibilities = inputModel.JobResponsibilities,
                JobRequirements = inputModel.JobRequirements,
                Benefits = inputModel.Benefits,
                ApplicationDate = inputModel.ApplicationDate,
                StartingDate = inputModel.StartingDate,
            };

            await this.jobPostsRepository.AddAsync(jobPost);
            await this.jobPostsRepository.SaveChangesAsync();

            return jobPost.Id;
        }
    }
}

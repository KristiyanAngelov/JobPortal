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

        public async Task AddCandidateAsync(string jobPostId, Worker candidate)
        {
            var jobPost = this.jobPostsRepository.All().FirstOrDefault(x => x.Id == jobPostId);
            var workerJobPost = new WorkerJobPost()
            {
                CandidateId = candidate.Id,
                Candidate = candidate,
                JobPostId = jobPostId,
                JobPost = jobPost,
            };
            candidate.JobApplications.Add(workerJobPost);
            jobPost.Candidates.Add(workerJobPost);

            await this.jobPostsRepository.SaveChangesAsync();

        }

        public ICollection<T> GetAll<T>()
        {
            return this.jobPostsRepository
                .All()
                .To<T>()
                .ToList();
        }

        public ICollection<JobPost> GetAll()
        {
            return this.jobPostsRepository
                .All()
                .ToList();
        }

        public JobPost GetById(string jobId)
        {
            return this.jobPostsRepository
                .All()
                .FirstOrDefault(x => x.Id == jobId);
        }

        public T GetById<T>(string jobId)
        {
            return this.jobPostsRepository
                .All()
                .Where(x => x.Id == jobId)
                .To<T>()
                .FirstOrDefault();
        }
    }
}

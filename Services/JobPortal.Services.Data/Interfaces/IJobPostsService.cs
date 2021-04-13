﻿namespace JobPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using JobPortal.Web.ViewModels.JobPost;

    public interface IJobPostsService
    {
        // CRUD
        public Task<string> CreateAsync(JobPostCreateViewModel inputModel, string companyId);

        public ICollection<T> GetAllJobPosts<T>();

        public T GetJobById<T>(string jobId);
    }
}
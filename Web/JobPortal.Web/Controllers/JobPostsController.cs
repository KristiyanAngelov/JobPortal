namespace JobPortal.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPortal.Common;
    using JobPortal.Data.Models;
    using JobPortal.Data.Models.Enums;
    using JobPortal.Services.Data;
    using JobPortal.Web.ViewModels.JobPost;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class JobPostsController : BaseController
    {
        private const int PostsPerPageDefaultValue = 5;
        private readonly IJobPostsService jobPostsService;
        private readonly UserManager<ApplicationUser> userManager;

        public JobPostsController(IJobPostsService jobPostsService, UserManager<ApplicationUser> userManager)
        {
            this.jobPostsService = jobPostsService;
            this.userManager = userManager;
        }

        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(List<JobType> jobTypes = null, string location = null)
        {

            return this.RedirectToAction("All", new { jobTypes, location });
        }

        public IActionResult All(int page = 1, int perPage = PostsPerPageDefaultValue, List<JobType> jobTypes = null, string location = null)
        {
            var pagesCount = (int)Math.Ceiling(this.jobPostsService.GetAllJobPosts().Count() / (decimal)perPage);

            var posts = this.jobPostsService
                .GetAllJobPosts<JobPostViewModel>()
                .Skip(perPage * (page - 1))
                .Take(perPage);

            if (jobTypes.Any())
            {
                posts = posts.Where(x => jobTypes.Contains(x.JobType));
            }

            if (!string.IsNullOrEmpty(location))
            {
                posts = posts.Where(x => x.Location == location);
            }

            var model = new AllJobPostsViewModel
            {
                JobPosts = posts.ToList(),
                CurrentPage = page,
                PagesCount = pagesCount,
            };

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdminAndCompanyRolesRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdminAndCompanyRolesRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(JobPostCreateViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var currentCompanyUser = await this.userManager.GetUserAsync(this.HttpContext.User);

            await this.jobPostsService.CreateAsync(input, currentCompanyUser.Id);

            return this.RedirectToAction("All");
        }

        public IActionResult GetById(string id)
        {
            var viewModel = this.jobPostsService.GetJobById<JobPostViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}

namespace JobPortal.Web.Controllers
{
    using System.Threading.Tasks;

    using JobPortal.Common;
    using JobPortal.Data.Models;
    using JobPortal.Services.Data;
    using JobPortal.Web.ViewModels.JobPost;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class JobPostsController : BaseController
    {
        private readonly IJobPostsService jobPostsService;
        private readonly UserManager<ApplicationUser> userManager;

        public JobPostsController(IJobPostsService jobPostsService, UserManager<ApplicationUser> userManager)
        {
            this.jobPostsService = jobPostsService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            return this.View();
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

            var currentCompanyUser = await this.userManager.GetUserAsync(this.User);

            await this.jobPostsService.CreateAsync(input, currentCompanyUser.Id);

            return this.RedirectToAction("All");
        }
    }
}

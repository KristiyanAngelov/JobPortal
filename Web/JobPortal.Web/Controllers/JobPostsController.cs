namespace JobPortal.Web.Controllers
{
    using System.Threading.Tasks;

    using JobPortal.Common;
    using JobPortal.Services.Data;
    using JobPortal.Web.ViewModels.JobPost;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class JobPostsController : BaseController
    {
        private readonly IJobPostsService jobPostsService;

        public JobPostsController(IJobPostsService jobPostsService)
        {
            this.jobPostsService = jobPostsService;
        }

        public IActionResult All()
        {
            return this.View();
        }

        //[Authorize(Roles = GlobalConstants.AdminAndCompanyRolesRoleName)]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        //[Authorize(Roles = GlobalConstants.AdminAndCompanyRolesRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(JobPostCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.jobPostsService.CreateAsync(input);

            return this.RedirectToAction("All");
        }
    }
}
